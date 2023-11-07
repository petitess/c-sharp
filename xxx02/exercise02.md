## Create API controller - EntityFramework

### Createa a User-model
```cs
public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public bool Active { get; set; }
}
```



### Create a data context  (install automapper, EntityFrameworkCore, EntityFrameworkCore.SqlServer)
```cs
public class DataContextEF : DbContext
{
    private readonly IConfiguration _config;
    public DataContextEF(IConfiguration config)
    {
        _config = config;
    }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        if(optionBuilder.IsConfigured)
        {
            optionBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                optionBuilder => optionBuilder.EnableRetryOnFailure());
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TutorialAppSchema");
        modelBuilder.Entity<User>()
            .ToTable("Users", "TutorialAppSchema")
            .HasKey(u => u.UserId);
    }
}
```
### Create a database connection

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true"
  },
```
### Create CORS policy
```cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((options) =>
{
    options.AddPolicy("DevCors", (corsBuilder) =>
    {
        corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();

    });
    options.AddPolicy("ProdCors", (corsBuilder) =>
    {
        corsBuilder.WithOrigins("https://myproductionsite.com")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();

    });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
}
else
{
    app.UseCors("ProdCors");
}
```
### Create a UserController
```cs
[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;
    IMapper _mapper;
    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
        _mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, User>();
        }));
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers() 
    {
        IEnumerable<User> users = _entityFramework.Users.ToList();
        return users;
    }

    [HttpGet("GetUser/{userId}")]
    public User GetUser(int userId) 
    {
        User? user = _entityFramework.Users
            .Where(u => u.UserId == userId)
            .FirstOrDefault<User>();
        if (user != null) 
        {
        return user;
        }
        throw new Exception("Failed to get user");
    }
    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userX = _entityFramework.Users
            .Where(u => u.UserId == user.UserId)
            .FirstOrDefault<User>();
        if (userX != null)
        {
            userX.FirstName = user.FirstName;
            userX.LastName = user.LastName;
            userX.Email = user.Email;
            userX.Gender = user.Gender;
            userX.Active = user.Active;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
        }
        throw new Exception("Failder to update user");
    }
    [HttpPost("NewUser")]
    public IActionResult NewUser(User user)
    {
        User userX = _mapper.Map<User>(user);
        _entityFramework.Add(userX);
        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }
        throw new Exception("Failed to add a new user.");
    }
}
```
