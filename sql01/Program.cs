using Computer.Models;
using Dapper;
using DapperX.data;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContextDapper dapper = new DataContextDapper();
            string sqlCommand = "SELECT GETDATE()";
            DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

            Computer.Models.Computer myComputer = new Computer.Models.Computer()
            {
                Motherboard = "Z1255",
                CPUCores = 4,
                HasWifi = true,
                HasLTE = false,
                VideoCard = "RTX 2060"
            };

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

            //int result = dapper.ExecuteSqlWithRowCount(sql);
            bool result = dapper.ExecuteSql(sql);

            string sqlSelect = @"SELECT 
                Computer.Motherboard,
                Computer.CPUCores,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.VideoCard 
                FROM TutorialAppSchema.Computer";

            IEnumerable<Computer.Models.Computer> computers = dapper.LoadData<Computer.Models.Computer>(sqlSelect);
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
        }
    }
}
