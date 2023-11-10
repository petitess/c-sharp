using AutoMapper;
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

            string computerJSON = File.ReadAllText("..\\..\\..\\ComputersSnake.json");

            IEnumerable<Computer.Models.Computer>? computers = JsonSerializer.Deserialize<IEnumerable<Computer.Models.Computer>>(computerJSON);

            if (computers != null)
            {
                foreach (Computer.Models.Computer computer in computers)
                {
                    //Console.WriteLine(computer.Price);

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
                     + "','" + 0 //computer.Price - doesnt work for some reason
                     + "','" + EscapeSingleQuote(computer.VideoCard)
                     + "')";
                    //Load data in database
                   dapper.ExecuteSql(sql);
                }
            }
        }
        static string EscapeSingleQuote(string input)
        {
            if (input != null)
            { 
            string output = input.Replace("'", "''");
            return output;
            }
            return "";
        }
        
    }
}