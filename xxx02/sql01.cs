//Check the connection to database
string connection = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true" ;
IDbConnection dbConnection = new SqlConnection(connection);
string sqlCommand = "SELECT GETDATE()";
DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);
Console.WriteLine(rightNow.ToString()); 
//Write data to database
string connection = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true" ;
IDbConnection dbConnection = new SqlConnection(connection);
string sql = @"INSERT INTO TutorialAppSchema.Computer (
    Motherboard,
    CPUCores,
    HasWifi,
    HasLTE,
    VideoCard
    ) VALUES ('" + myComputer.Motherboard 
         + "','" + myComputer.CPUCores
         + "','" + myComputer.HasWifi
         + "','" + myComputer.HasLTE
         + "','" + myComputer.VideoCard
         + "')";

Console.WriteLine(sql);
int result = dbConnection.Execute(sql);
Console.WriteLine(result);
