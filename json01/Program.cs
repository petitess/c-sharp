using DapperX.data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            DataContextDapper dapper = new DataContextDapper(config);

            string computerJSON = File.ReadAllText("..\\..\\..\\Computers.json");
            //Read the file
            //Console.WriteLine(computerJSON);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            IEnumerable<Computer.Models.Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer.Models.Computer>>(computerJSON, options);
            //You can use Newtonsoft.Json insteas of System.Text.Json:
            //IEnumerable<Computer.Models.Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer.Models.Computer>>(computerJSON);
            if (computers != null )
            {
                foreach (Computer.Models.Computer computer in computers)
                {
                    Console.WriteLine(computer.Motherboard);
                    string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
                ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
                     + "','" + computer.HasWifi
                     + "','" + computer.HasLTE
                     + "','" + computer.ReleaseDate
                     + "','" + computer.Price
                     + "','" + EscapeSingleQuote(computer.VideoCard)
                     + "')";
                    //Load data in database
                   dapper.ExecuteSql(sql);
                }
            }

            string computerCopySystem = JsonSerializer.Serialize(computers, options);
            File.WriteAllText("..\\..\\..\\ComputersJsonSerializer.json", computerCopySystem);
            //Newtonsoft.Json version:
            //string computerCopyNewtonsoft = JsonConvert.SerializeObject(computers);
            //File.WriteAllText("..\\..\\..\\ComputersNewtonsoft.json", computerCopyNewtonsoft);
        }
        static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");    
            return output;
        }
    }
}