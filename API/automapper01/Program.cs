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

            Mapper mapper = new Mapper(new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Computer.Models.ComputerSnake, Computer.Models.Computer>()
                    .ForMember(destination => destination.ComputerId, options =>
                        options.MapFrom(source => source.computer_id))
                    .ForMember(destination => destination.Motherboard, options =>
                        options.MapFrom(source => source.motherboard))
                    .ForMember(destination => destination.HasWifi, options =>
                        options.MapFrom(source => source.has_wifi))
                    .ForMember(destination => destination.HasLTE, options =>
                        options.MapFrom(source => source.has_lte))
                    .ForMember(destination => destination.ReleaseDate, options =>
                        options.MapFrom(source => source.release_date))
                    .ForMember(destination => destination.Price, options =>
                        options.MapFrom(source => source.price))
                    .ForMember(destination => destination.VideoCard, options =>
                        options.MapFrom(source => source.video_card));
            }));

            IEnumerable<Computer.Models.ComputerSnake>? computers = JsonSerializer.Deserialize<IEnumerable<Computer.Models.ComputerSnake>>(computerJSON);

            if (computers != null)
            {
                IEnumerable<Computer.Models.Computer> computerResult = mapper.Map<IEnumerable<Computer.Models.Computer>>(computers);
                foreach (Computer.Models.Computer computer in computerResult)
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
                    //Load data into database
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