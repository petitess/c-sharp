using Azure.Data.Tables;
using Newtonsoft.Json.Linq;

namespace table01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tempJSON = @"
{
    ""request"": {
        ""type"": ""City"",
        ""query"": ""Gothenburg, Sweden"",
        ""language"": ""en"",
        ""unit"": ""m""
    },
    ""location"": {
        ""name"": ""Gothenburg"",
        ""country"": ""Sweden"",
        ""region"": ""Vastra Gotaland"",
        ""lat"": ""57.717"",
        ""lon"": ""11.967"",
        ""timezone_id"": ""Europe/Stockholm"",
        ""localtime"": ""2023-12-03 15:19"",
        ""localtime_epoch"": 1701616740,
        ""utc_offset"": ""1.0""
    },
    ""current"": {
        ""observation_time"": ""02:19 PM"",
        ""temperature"": -6,
        ""weather_code"": 113,
        ""weather_icons"": [
            ""https://cdn.worldweatheronline.com/images/wsymbols01_png_64/wsymbol_0001_sunny.png""
        ],
        ""weather_descriptions"": [
            ""Sunny""
        ],
        ""wind_speed"": 4,
        ""wind_degree"": 22,
        ""wind_dir"": ""NNE"",
        ""pressure"": 1019,
        ""precip"": 0,
        ""humidity"": 86,
        ""cloudcover"": 0,
        ""feelslike"": -8,
        ""uv_index"": 2,
        ""visibility"": 10,
        ""is_day"": ""yes""
    }
}";
            DateTime time = DateTime.Now;
            string timeStamp = time.ToString("dd/MM/yyyy HH:mm");
            dynamic weather = JObject.Parse(tempJSON);
            int temperature = weather.current.temperature;
            string city = weather.location.name;
            var serviceClient = new TableServiceClient("DefaultEndpointsProtocol=https;AccountName=X;AccountKey=X==;EndpointSuffix=core.windows.net");
            TableClient table = serviceClient.GetTableClient("weather");
            table.CreateIfNotExists();
            var tableEntity = new TableEntity(city , Guid.NewGuid().ToString()) {
                {
                    "temperature",
                    temperature
                }, {
                    "Time",
                    timeStamp
                }
            };
            table.AddEntity(tableEntity);
            Console.ReadKey();
        }
    }
}
