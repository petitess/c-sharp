using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace SetSecrets
{
    internal class PwState01
    {
        public async Task<Hashtable> GetPassword(string? apiKey, [Description("password id")]string? id, [Optional]string? urlQuery)
        {
            Console.WriteLine("PWSTATE: ");
            if (apiKey == null)
            {
                throw new ArgumentException("API key not provided");
            }
            else
            {
                string? url = $"https://pwstate.abcd.tech/api/passwords/{id}{urlQuery}";

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("APIKey", apiKey);
                var httpResponseMessage = await httpClient.GetAsync(url);

                Console.WriteLine($"{id}: {httpResponseMessage.StatusCode}");

                var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
                dynamic? response = JsonConvert.DeserializeObject(jsonResult);

                Hashtable? secrets = new Hashtable();

                if (response != null)
                {

                    foreach (dynamic res in response)
                    {
                        if (httpResponseMessage.StatusCode.ToString() == "OK")
                        {
                            secrets.Add(res.Notes, res.Password);
                        }
                    }
                    return secrets;
                }
                else
                {
                    throw new ArgumentException("Empty List");
                }
            }
        }

        public async Task<Hashtable> GetUrl(string? apiKey, [Description("password id")] string? id, [Optional] string? urlQuery)
        {
            Console.WriteLine("PWSTATE URL: ");
            if (apiKey == null)
            {
                throw new ArgumentException("API key not provided");
            }
            else
            {
                string? url = $"https://pwstate.abcd.tech/api/passwords/{id}{urlQuery}";

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("APIKey", apiKey);
                var httpResponseMessage = await httpClient.GetAsync(url);

                Console.WriteLine($"{id}: {httpResponseMessage.StatusCode}");

                var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
                dynamic? response = JsonConvert.DeserializeObject(jsonResult);

                Hashtable? secrets = new Hashtable();

                if (response != null)
                {

                    foreach (dynamic res in response)
                    {
                        if (httpResponseMessage.StatusCode.ToString() == "OK" && res.URL != "")
                        {
                            secrets.Add(res.Notes, res.URL);
                        }
                    }
                    return secrets;
                }
                else
                {
                    throw new ArgumentException("Empty List");
                }
            }
        }
    }
}
