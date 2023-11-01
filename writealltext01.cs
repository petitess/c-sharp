namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            string sql = "\n" + @"INSERT INTO TutorialAppSchema.Computer (
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
                     + "')\n";
            //Version 1
            File.WriteAllText("..\\..\\..\\log.txt", sql);
            //Version 2
            File.WriteAllText("..\\..\\..\\log.txt", "\n" + sql + "\n");
            //Version 3
            using StreamWriter openFile = new("..\\..\\..\\log.txt", append: true);
            openFile.WriteLine(sql);
        }
    }
}
