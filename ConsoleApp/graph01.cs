using Azure.Identity;
using Azure.Core;
using Newtonsoft.Json;

namespace CalenderApp
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            string tenantId = "123";
            string clientId = "456";
            string clientSecret = "789";
            string user = "bettysnyder@abc.se";


            Program program = new Program();
            var token = program.GetGraphToken(tenantId, clientId, clientSecret).Result;
            var calender_id = program.GetCalenderId(token, user).Result;

            List<Events> events = await program.GetCalenderEvents(token, user, calender_id);
            Console.WriteLine("ORGANIZER: " + events.Where(e => e.organizer.emailAddress.address == "linda.berg@abc.se").First().organizer.emailAddress.name);

            foreach (var e in events.Where(e => e.start.dateTime.ToString().Contains("2025-04-08")))
            {
                Console.WriteLine(e.organizer.emailAddress.address);
                Console.WriteLine(e.start.dateTime);
                Console.WriteLine("\n");
            };
        }

        private async Task<List<Events>> GetCalenderEvents(string token, string user,  string calender_id)
        {
            //GET request
            string Url = $"https://graph.microsoft.com/v1.0/users/{user}/calendars/{calender_id}/events/?$select=start,end,organizer,location";
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            string MgToken = token;
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + MgToken);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var httpResponseKey = httpClient.GetAsync(Url);
            //Console.WriteLine("IsSuccessStatusCode: " + httpResponseKey.Result);
            var jsonResult = await httpResponseKey.Result.Content.ReadAsStringAsync();
            EventsRoot eventX = JsonConvert.DeserializeObject<EventsRoot>(jsonResult);

            return eventX.value;
        }

        private async Task<string> GetCalenderId(string token, string user)
        {
            //GET request
            string Url = $"https://graph.microsoft.com/v1.0/users/{user}/calendars?$filter=isDefaultCalendar eq true";
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            string MgToken = token;
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + MgToken);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var httpResponseKey = httpClient.GetAsync(Url);
            var jsonResult = await httpResponseKey.Result.Content.ReadAsStringAsync();
            dynamic? response = JsonConvert.DeserializeObject(jsonResult);

            string id;
            foreach (var e in response.value)
            {
                id = e.id;
                return id;
            }
            return null;

        }

        private async Task<string> GetGraphToken(string tenantId, string clientId, string clientSecret)
        {
            AccessToken token = await new ChainedTokenCredential(
             new ClientSecretCredential(tenantId, clientId, clientSecret)
            ).GetTokenAsync(
                 new TokenRequestContext(
                 new[] { "https://graph.microsoft.com/.default" }
                 )
             ).ConfigureAwait(true);

            return token.Token;
        }
    }

    public class EventsRoot
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
        [JsonProperty("value")]
        public List<Events> value { get; set; }
}

    public class Events
    {
        [JsonProperty("@odata.etag")]
        public string odataetag { get; set; }
        public string id { get; set; }
        public EventStart start { get; set; }
        public EventEnd end { get; set; }
        public EventLocation location { get; set; }
        public EventOrganizer organizer { get; set; }
    }

    public class EventStart
    {
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }
    }
    public class EventEnd
    {
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }
    }
    public class EventLocation
    {
        public string displayName { get; set; }
        public string locationType { get; set; }
        public string uniqueId { get; set; }
        public string uniqueIdType { get; set; }
    }
    public class EventOrganizer
    {
        public EventEmailAddress emailAddress { get; set; }
    }
    public class EventEmailAddress
    {
        public string name { get; set; }
        public string address { get; set; }
    }
}
