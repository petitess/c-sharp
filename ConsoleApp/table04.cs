using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsolePipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's the make of this Car?");
            string? make = Console.ReadLine();
            Console.WriteLine("What's the model of this Car?");
            string? model = Console.ReadLine();
            Console.WriteLine("Production year?");
            string? year = Console.ReadLine();
            Console.WriteLine("Color?");
            string? color = Console.ReadLine();

            var createCar = PostStorage(make = "Porsche", model = "Panamera", year = "2024", color = "red");

            static string PostStorage(string make, string model, string year, string color)
            {
                string BaseUrl = $"https://sttrustprod01.table.core.windows.net/cars";
                string Sas = "sv=2022-11-02&ss=t&srt=sco&sp=rwdlacxxxxx";
                string RequestUrl = $"{BaseUrl}?{Sas}";
                DateTime dateTime = DateTime.Now;

                Car car = new Car
                {
                    RowKey = Guid.NewGuid().ToString(),
                    make = make,
                    model = model,
                    year = year,
                    color = color
                };

                var carString = System.Text.Json.JsonSerializer.Serialize(car);

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=fullmetadata");
                httpClient.DefaultRequestHeaders.Add("x-ms-date", $"{dateTime}");
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2020-04-08");
                
                var httpResponse = httpClient.PostAsync(RequestUrl, 
                    new StringContent(carString, Encoding.UTF8, "application/json"));

                string statusCode = httpResponse.Result.StatusCode.ToString();
                Console.WriteLine(statusCode);

                return statusCode;
            }
        }
    }

    [Table("cars")]
    public class Car
    {
        public string? RowKey { get; set; }
        public string? make { get; set; }
        public string? model { get; set; }
        [MaxLength(12)]
        public string? year { get; set; }
        public string? color { get; set; }
        public string? PartitionKey { get; set; } = "cars";
    }
}
