using Azure.Core;
using Azure.Identity;
using Newtonsoft.Json.Linq;
using System.Net;

namespace ConsoleApim
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AccessToken token =
                await new DefaultAzureCredential()
                .GetTokenAsync(
                    new TokenRequestContext(
            new[] { "https://management.azure.com/.default" }
            ));
            await Console.Out.WriteLineAsync(token.ExpiresOn.ToString());
            string subid = "x-2b8f-4e69-9817-x";
            string rgname = "rg-infra-apim-dev-we-01";
            string apimname = "apim-infra-x-dev-we-01";
            string apiversion = "2023-09-01-preview";
            string urlAzure = $"https://management.azure.com/subscriptions/{subid}/resourceGroups/{rgname}/providers/Microsoft.ApiManagement/service/{apimname}/apis?api-version={apiversion}";
            var httpRequestAzure = (HttpWebRequest)WebRequest.Create(urlAzure);

            try
            {
                httpRequestAzure.Accept = "application/json";
                httpRequestAzure.Headers["Authorization"] = "Bearer " + token.Token;
                //GET all APIs
                var httpResponseAzure = (HttpWebResponse)httpRequestAzure.GetResponse();
                Console.WriteLine("StatusCode: " + httpResponseAzure.StatusCode + " Method " + httpResponseAzure.Method);
                var streamReaderAzure = new StreamReader(httpResponseAzure.GetResponseStream());
                var resultAzure = streamReaderAzure.ReadToEnd();
                dynamic dataApis = JObject.Parse(resultAzure);
                //GET Swagger files for each API
                foreach (dynamic dataApi in dataApis.value)
                {
                    //Show API name
                    Console.WriteLine(dataApi.name);
                    string format = "openapi-link"; //For json output:openapi%2Bjson, for url output
                    //https://learn.microsoft.com/en-us/rest/api/apimanagement/api-export/get
                    string urlSwagger = $"https://management.azure.com/subscriptions/{subid}/resourceGroups/{rgname}/providers/Microsoft.ApiManagement/service/{apimname}/apis/{dataApi.name}?format={format}&export=true&api-version={apiversion}";
                    var httpRequestSwagger = (HttpWebRequest)WebRequest.Create(urlSwagger);
                    httpRequestSwagger.Accept = "application/json";
                    httpRequestSwagger.Headers["Authorization"] = "Bearer " + token.Token;
                    var httpResponseSwagger = (HttpWebResponse)httpRequestSwagger.GetResponse();
                    Console.WriteLine("StatusCode: " + httpResponseSwagger.StatusCode + " Method " + httpResponseSwagger.Method);
                    var streamReaderSwagger = new StreamReader(httpResponseSwagger.GetResponseStream());
                    var resultSwagger = streamReaderSwagger.ReadToEnd();
                    dynamic dataSwagger = JObject.Parse(resultSwagger);
                    //Show Swagger file/link
                    Console.WriteLine(dataSwagger.properties.value.link);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
