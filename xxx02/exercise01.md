## Create API controller

### Create a data context  (install dapper and automapper)
```cs
public class DataContextDapper
{
    private readonly IConfiguration _config;
    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }
    public IEnumerable<T> LoadData<T>(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Query<T>(sql);
    }
    public T LoadDataSingle<T>(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingle<T>(sql);
    }
    public bool ExecuteSql(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql) > 0;
    }
    public int ExecuteSqlWithRowCount(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql);
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
### Createa a User-model
```cs
public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public bool Active { get; set; }
}
```
### Create a UserController
```cs
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }
    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
    string sql = @"
       SELECT [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] FROM TutorialAppSchema.Users";
    IEnumerable<User> users = _dapper.LoadData<User>(sql);
    return users;
}
    [HttpGet("GetSingleUser/{UserId}")]
    public User GetSingleUser(int UserId)
    {
        string sql = @"SELECT [UserId],
                        [FirstName],
                        [LastName],
                        [Email],
                        [Gender],
                        [Active] FROM TutorialAppSchema.Users
                        WHERE UserId = " + UserId.ToString();
        User user = _dapper.LoadDataSingle<User>(sql);
        return user;
    }
}
```
## Intermediate
### Add a PUT request
```cs
public bool ExecuteSql(string sql)
{
    IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    return dbConnection.Execute(sql) > 0;
}

public int ExecuteSqlWithRowCount(string sql)
{
    IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    return dbConnection.Execute(sql);
}
```
```cs
[HttpPut("EditUser")]
public User EditUser(User user)
{
    string sql = @"
                UPDATE TutorialAppSchema.Users
                SET 
                [FirstName] = '" + user.FirstName + 
                "', [LastName] = '" + user.LastName + 
                "', [Email] = '" + user.LastName +
                "', [Gender] = '" + user.Gender + 
                "', [Active] = '" + user.Active + 
                "' WHERE UserId = " + +user.UserId;
    if (_dapper.ExecuteSql(sql))
    {
        return user;
    }
    throw new Exception("Failed to update user");
}
```
