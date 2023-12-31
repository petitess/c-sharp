#### 1. Models
    - Create models with properties
        - Stocks
        - Comment
#### 2. Entity Framework
    - Microsoft.EntityFrameworkCore.Tools
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Design
    - Create ApplicationDbContext
        - Inheritance DbContext
        - Create constractor
        - Create DbSet to add tables
        - Create connection to database
        - Place connection string in appsetings.json
    - Create database manually
    - Migrate to databse 
        - dotnet tool install --global dotnet-ef
        - dotnet ef migrations add init
        - dotnet ef database update
#### 3. Controllers
    - Create controllers
        - Inheritance ControllerBase
        - Create Route and ApiContoller
        - Create a constractor with ApplicationDbContext
        - Create private field
        - Create HTTP GET request
        - Add Controller to program.cs
#### 4. Create DTO for GET
#### 5. Mapper for GET
    - Create mappers: StockMappers
    - Update HTTP Get request
#### 6. Create DTO for POST
#### 7. Mapper for POST
    - Create HTTP POST request
#### 8. Create DTO for PUT
    - Create HTTP PUT request
    - Create HTTP DELETE request

#### 9x. Identity

Microsoft.AspNetCore.Identity.EntityFrameworkCore

Microsoft.Extensions.Identity.Core

Microsoft.AspNetCore.Authentication.JwtBearer

IDENITY
Add model for user
- Inheritance : IdentityUser 
- Update inheritance for ApplicationDbContext.cs to : IdentityDbContext<AppUser>
- In program.cs AddIdentity<AppUser, IdentityRole>
- In program.cs AddAuthentication
- in appsettings.json add JWT config
run
dotnet ef migrations add Identity
dotnet ef database update

#### 10. Register
    - Create RegisterDto
    - Create AccountController
        - Inheritance ControllerBase
        - Create Route and ApiContoller
        - Create a constractor with UserManager<AppUser>
    - In ApplicationDbContext override OnModelCreating(ModelBuilder builder)
        - List<IdentityRole> roles = new List<IdentityRole> {};
    
