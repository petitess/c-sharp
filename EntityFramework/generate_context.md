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
