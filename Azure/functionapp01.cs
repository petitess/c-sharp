using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Core;
using Azure.Identity;
using Newtonsoft.Json;
using System.Text;

namespace HttpClient
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            //GET request
            string Url = $"https://google.com";
            Console.WriteLine("URL: " + Url);
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            var httpResponseKey = await httpClient.GetAsync(Url);
            Console.WriteLine("IsSuccessStatusCode: " + httpResponseKey.IsSuccessStatusCode);
            //Azure Auth
            AccessToken token =
                 await new DefaultAzureCredential()
                .GetTokenAsync(
                    new TokenRequestContext(
            new[] { "https://management.azure.com/.default" }
            ));
            Console.WriteLine("Azure: " + token.Token.ToString()?.Substring(0, 15));

            string subid = "0dcc13b7-1a10-483e-95aa-fe7e71802e2e";
            string rgname = "rg-xxx-func-dev-we-01";
            string apiversion = "2024-03-01";
            string urlAzure = $"https://management.azure.com/subscriptions/{subid}/resourceGroups/{rgname}?api-version={apiversion}";

            Console.WriteLine("URL: " + urlAzure);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(new
            {
                tags = new { Status = httpResponseKey.IsSuccessStatusCode, Time = $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm")}" }

            }), Encoding.UTF8, "application/json");

            System.Net.Http.HttpClient httpClientAzure = new System.Net.Http.HttpClient();
            httpClientAzure.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClientAzure.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
            //PATCH request
            var httpResponseMessage = await httpClientAzure.PatchAsync(urlAzure, jsonContent);
            //JSON
            var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
            dynamic? response = JsonConvert.DeserializeObject(jsonResult);

            Console.WriteLine("provisioningState: " + response.properties.provisioningState);

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("IsSuccessStatusCode: " + httpResponseKey.IsSuccessStatusCode + ", IsSuccessStatusCodeAzure: " + httpResponseMessage?.IsSuccessStatusCode);
        }
    }
}
