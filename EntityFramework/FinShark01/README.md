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
    - 