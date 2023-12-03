### Program.cs
```cs
internal class Program
{
    private static async Task Main(string[] args)
    {
        string url = "https://my-json-server.typicode.com/typicode/demo/posts";
        //A http client to send the get request
        HttpClient httpClient = new HttpClient();

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
        try
        {
            var httpResponseMessage = await httpClient.GetAsync(url);
            //Read the string from response's content
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            //Print the JSON content
            //Console.WriteLine(tempJSON);
            //Deserialize the JSON response into a C# array of type Post[]
            var weather = JsonConvert.DeserializeObject<Root>(tempJSON);
            //Print the array objects using a foreach loop
            //Console.WriteLine($"{weather.location.name}: {weather.location.country}");

            if (weather.current.temperature < 5 && weather.current.temperature >= -5)
            {
                Console.WriteLine("It's {0} in {1}. Take a jacket.", weather.current.temperature, weather.location.name);
            }else if (weather.current.temperature < -5)
            {
                Console.WriteLine("It's {0} in {1}. Take a thick jacket.", weather.current.temperature, weather.location.name);
            }else
            {
                Console.WriteLine("It's {0} in {1}.", weather.current.temperature, weather.location.name);
            };

        }
        catch (Exception ex)
        {   
            Console.WriteLine(ex.Message);
        }
        finally { httpClient.Dispose(); }
    }
}
```
### Weather.cs
```cs
namespace json01
{
    public class Current
    {
        public string observation_time { get; set; }
        public int temperature { get; set; }
        public int weather_code { get; set; }
        public List<string> weather_icons { get; set; }
        public List<string> weather_descriptions { get; set; }
        public int wind_speed { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public int pressure { get; set; }
        public int precip { get; set; }
        public int humidity { get; set; }
        public int cloudcover { get; set; }
        public int feelslike { get; set; }
        public int uv_index { get; set; }
        public int visibility { get; set; }
        public string is_day { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        public int localtime_epoch { get; set; }
        public string utc_offset { get; set; }
    }

    public class Request
    {
        public string type { get; set; }
        public string query { get; set; }
        public string language { get; set; }
        public string unit { get; set; }
    }

    public class Root
    {
        public Request request { get; set; }
        public Location location { get; set; }
        public Current current { get; set; }
    }
}
```
