//Check the connection to database
string connection = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true" ;
IDbConnection dbConnection = new SqlConnection(connection);
string sqlCommand = "SELECT GETDATE()";
DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);
Console.WriteLine(rightNow.ToString()); 
//Write data to a database
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
//Get data from a database
string connection = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true" ;
IDbConnection dbConnection = new SqlConnection(connection);
string sqlSelect = @"SELECT 
    Computer.Motherboard,
    Computer.CPUCores,
    Computer.HasWifi,
    Computer.HasLTE,
    Computer.VideoCard 
    FROM TutorialAppSchema.Computer";

IEnumerable<Computer.Models.Computer> computers = dbConnection.Query<Computer.Models.Computer>(sqlSelect);
Console.WriteLine("'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate',"
    + ", 'Prise', 'VideoCard'");
foreach(Computer.Models.Computer comp in computers)
{
    Console.WriteLine("'" + myComputer.Motherboard 
         + "','" + myComputer.CPUCores
         + "','" + myComputer.HasWifi
         + "','" + myComputer.HasLTE
         + "','" + myComputer.VideoCard
         + "'");
}
