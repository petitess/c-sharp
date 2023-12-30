#### 1. Create database with 2 tables: "Stocks" and "Comments"
#### 2. Models
    - Create models with properties according to table datatypes
        - Stocks
        - Comment
#### 3. Entity Framework
    - Install:
        - Microsoft.EntityFrameworkCore.Tools
        - Microsoft.EntityFrameworkCore.SqlServer
        - Microsoft.EntityFrameworkCore.Design
        - Microsoft.AspNetCore.Mvc.NewtonsoftJson
        - Newtonsoft.Json
    - Create ApplicationDbContext.cs
        - Inheritance DbContext
        - Create constractor with (DbContextOptions): base()
        - Create DbSet to add tables
        - Create connection to database
        - Place connection string in appsetings.json
        - AddDbContext in Program.cs
        - ReferenceLoopHandling.Ignore in Program.cs
    - In .csproj set this: <InvariantGlobalization>false</InvariantGlobalization>
#### 4. Interface
    - Create Interfaces 
        - Create methhods
#### 5. Repositort
    - Create repositories with Inheritance
        - Implement interface
    - Create constractor with ApplicationDbContext
    - Build functions for methods

#### 6. DTO
    - Create DTO for GET 
#### 7. Mappers for GET
    - Create mapper StockMappers
        - Create Dtos CreateStockRequestDto, 
        - Create methods ToStockDto, ToStockFromCreateDto
    -  Create mapper CommentMappers
        - Create Dtos CreateCommentDto, UpdateCommentRequestDto
        - Create methods ToCommentDto, ToCommentFromCreate, ToCommentFromUpdate
#### 8. Controllers
    - Create controllers
        - Inheritance ControllerBase
        - Create Route and ApiContoller
        - Create a constractor with Interface
        - Create private field
        - Create HTTP GET request
            - Task<IActionResult>
        - In program.cs builder.Services.AddScoped<IStockRepository, StockRepository>();


###########
<!--#### 5. Helper
    - Create a helper method for Stock
    - Create nre method in interface-->
#### 4. Controllers
    - Create controllers
        - Inheritance ControllerBase
        - Create Route and ApiContoller
        - Create a constractor with ApplicationDbContext
        - Create private field
        - Create HTTP GET request
        - Add Controller to program.cs
#### 5. Create DTO for GET
#### 6. Mapper for GET
    - Create mappers: StockMappers
    - Update HTTP Get request
#### 7. Create DTO for POST
#### 7. Mapper for POST
    - Create HTTP POST request
#### 8. Create DTO for PUT
    - Create HTTP PUT request
    - Create HTTP DELETE request
