# repo
| Name | Description |
| -----| ------------|
automapper01 | map JSON data 
automapper02 | map JSON data - Entity Framework
configfile01 |configuration file to connect to a SQL server
dapper01 | endpoints to modify database
dapper02 | token-based authentication
dapper03 | Stored Procedures
entityframework01 | endpoints to modify database
entityframework02 | endpoints to modify database - UserRepository
json01 | insert JSON data into SQL server
json02 | map JSON data - JSON property mapping
sql01 | insert data into a database - dapper
sql02 | insert data into a database - Entity Framework
sql03 | insert data into a database, Users, UserJobInfo, UserSalary

### CREATE API

1. Create Interface
    - create methods for API requests
2. Create Repository
    - Create inheritance
    - Implement interface
    - Create a constructor
    - Import Data Context and Mapper
    - Assign field for Data Context and Mapper
    - Build Database Calls
4. Create DTO 
5. Create Controller
    - Apply ApiController and Route
    - Create inheritance
    - Create a constractor
    - Assign field for IRepository and Mapper
    - Create HTTP requests
6. Create Mapping Profiles
7. Configure dependency injection
