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
```
### Create a UserController
```cs

```
