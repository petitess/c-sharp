### Generate DbContext for existing databse
1. Change
```XML
  <PropertyGroup>
    <InvariantGlobalization>false</InvariantGlobalization>
  </PropertyGroup>
```
2. Run in Package manager console
```
Scaffold-DbContext "Data Source=DESKTOP-CFCPFSG;Initial Catalog=BookStore;User ID=sa;Password=12345;Trust Server Certificate=True" -Provider "Microsoft.EntityFrameworkCore.SqlServer" -ContextDir Data -OutputDir Data
```
3. Remove OnConfiguring from DbContext
```cs
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CFCPFSG;Initial Catalog=BookStore;User ID=sa;Password=12345;Trust Server Certificate=True");
```
4. I Program.cs AddDbContext
```cs
var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
```
