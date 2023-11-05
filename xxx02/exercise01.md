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
    public IEnumerable<T> LoadData<T>(string sql) //method
    {
        IDbConnection dbConnection = new SqlConnetion(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Query<T>(sql);
    }
    public T LoadDataSingle<T>(string sql)
    {
        IDbConnection dbConnection = new SqlConnetion(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingle<T>(sql);
    }
}
```

  
### Create a database connection

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```
```cs
public UserController(IConfiguration config) 
{
    //Console.WriteLine(config.GetConnectionString("DefaultConnection"));
}
```
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
}
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


```
