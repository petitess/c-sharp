using Newtonsoft.Json.Linq;

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
                foreach (dynamic item in carList.Result.ToArray())
                {
                    Console.WriteLine(item.make);
                }
            }

            static async Task<List<object>> GetStorage()
            {
                string BaseUrl = $"https://sttrustprod01.table.core.windows.net/cars";
                string Sas = "sv=2022-11-02&ss=xxxxxxx";
                string RequestUrl = $"{BaseUrl}?{Sas}";
                DateTime dateTime = DateTime.Now;

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=fullmetadata");
                httpClient.DefaultRequestHeaders.Add("x-ms-date", $"{dateTime}");
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2020-04-08");
                var httpResponse =  await httpClient.GetAsync(RequestUrl);

                var jsonResult = await httpResponse.Content.ReadAsStringAsync();
                dynamic? response = JObject.Parse(jsonResult); ;

                List<object> carsResult = new();

                foreach (var c in response.value)
                {
                    //Console.WriteLine("Loop: " + c.ToString());
                    carsResult.Add(c);
                }

                return carsResult;
            }
        }
    }
}
