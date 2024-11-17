using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsolePipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carList = GetStorage();

            Console.WriteLine("Output: " + carList.Count());

            if (carList.ToArray() != null)
            {
                foreach (var item in carList.ToArray())
                {
                    Console.WriteLine(item.Make);
                }
            }

            static List<Car> GetStorage()
            //static dynamic GetStorage()
            {
                string BaseUrl = $"https://sttrustprod01.table.core.windows.net/cars";
                string Sas = "sv=2022-11-02&ss=t&srt=sco&sp=xxxxx";
                string RequestUrl = $"{BaseUrl}?{Sas}";
                DateTime dateTime = DateTime.Now;

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=fullmetadata");
                httpClient.DefaultRequestHeaders.Add("x-ms-date", $"{dateTime}");
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2020-04-08");
                var httpResponse = httpClient.GetAsync(RequestUrl);

                var jsonResult = httpResponse.Result.Content.ReadAsStringAsync().Result;
                dynamic? response = JObject.Parse(jsonResult); ;

                List<Car> carsResult = new();

                foreach (var c in response.value)
                {
                    carsResult.Add(new Car()
                    {
                        Id = c.RowKey,
                        Make = c.make,
                        Model = c.model,
                        Vin = c.year
                    });
                }

                return carsResult;
            }
        }
    }

    [Table("cars")]
    public class Car
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        [MaxLength(12)]
        public string? Vin { get; set; }
    }
}
