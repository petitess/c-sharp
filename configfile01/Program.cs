using Entity.data;
using Microsoft.Extensions.Configuration;

namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            DataContextEF entityFramework = new DataContextEF(config);

            Computer.Models.Computer myComputer = new Computer.Models.Computer()
            {
                Motherboard = "Z1255",
                CPUCores = 4,
                HasWifi = true,
                HasLTE = false,
                Price = 0,
                ReleaseDate = DateTime.Now,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                CPUCores,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
                ) VALUES ('" + myComputer.ComputerId
                     + "','" + myComputer.CPUCores
                     + "','" + myComputer.CPUCores
                     + "','" + myComputer.HasWifi
                     + "','" + myComputer.HasLTE
                     + "','" + myComputer.ReleaseDate
                     + "','" + myComputer.Price
                     + "','" + myComputer.VideoCard
                     + "')";

            IEnumerable<Computer.Models.Computer>? computers = entityFramework.Computer?.ToList<Computer.Models.Computer>();

            if (computers != null) { 
            Console.WriteLine("'ComputerId', 'Motherboard', 'CPUCores', 'HasWifi', 'HasLTE', 'ReleaseDate',"
                + ", 'Prise', 'VideoCard'");
            foreach(Computer.Models.Computer comp in computers)
            {
                Console.WriteLine("'" + comp.ComputerId
                     + "','" + comp.CPUCores
                     + "','" + comp.CPUCores
                     + "','" + comp.HasWifi
                     + "','" + comp.HasLTE
                     + "','" + comp.ReleaseDate
                     + "','" + comp.Price
                     + "','" + comp.VideoCard
                     + "'");
            }
            }
        }
    }
}