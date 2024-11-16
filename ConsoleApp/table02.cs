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

            Console.WriteLine("Output: " + carList.Result.Count());

            if (carList.Result.ToArray() != null)
            {
                foreach (var item in carList.Result.ToArray())
                {
                    Console.WriteLine(item.Make);
                }
            }

            static async Task<List<Car>> GetStorage()
            {
                string BaseUrl = $"https://sttrustprod01.table.core.windows.net/cars";
                string Sas = "sv=2022-11-02&ss=txxxxx";
                string RequestUrl = $"{BaseUrl}?{Sas}";
                DateTime dateTime = DateTime.Now;

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=fullmetadata");
                httpClient.DefaultRequestHeaders.Add("x-ms-date", $"{dateTime}");
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2020-04-08");
                var httpResponse =  await httpClient.GetAsync(RequestUrl);

                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                dynamic? response = JObject.Parse(jsonResult); ;

                List<Car> carsResult = new();

                foreach (var c in response.value)
                {
                    //Console.WriteLine("Loop: " + c.ToString());
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
