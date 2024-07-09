using Newtonsoft.Json;
using System.Text;

namespace SetSecrets
{
    internal class KeyVault
    {
        public async Task<object> SetKeyVaultSecret(string? AzToken, string? SubscriptionId, string? RgName, string? KvName, string? SecretName, string? SecretValue)
        {
            Console.WriteLine("KeyVault: ");
            string? GithubUser = Environment.GetEnvironmentVariable("GITHUB_TRIGGERING_ACTOR");
            string? SecretNameX = SecretName?.Replace(" ", "-").Replace("_", "-").Replace("<div>", "").Replace("</div>", "");
            string? Apiversion = "2023-07-01";
            string? UrlAzure = $"https://management.azure.com/subscriptions/{SubscriptionId}/resourceGroups/{RgName}/" +
                $"providers/Microsoft.KeyVault/vaults/{KvName}/secrets/{SecretNameX}?api-version={Apiversion}";

            Console.WriteLine("Azure Url: " + UrlAzure);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(new
            {
                properties = new { value = SecretValue , contentType = $"updated: {DateTime.Now.ToString("dd-MM-yyyy HH:mm")} by {GithubUser}" }

            }), Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AzToken);
            var httpResponseMessage = await httpClient.PutAsync(UrlAzure, jsonContent);
            Console.WriteLine(httpResponseMessage.StatusCode);
            var JsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
            dynamic? response = JsonConvert.DeserializeObject(JsonResult);

            if (httpResponseMessage.StatusCode.ToString() == "Conflict")
            {
                Console.WriteLine($"{httpResponseMessage.StatusCode}, {SecretNameX} secret is in a soft deleted state.");
                throw new ArgumentException($"Error Message: {response?.error.message}");
            } 
            else if (httpResponseMessage.StatusCode.ToString() == "Unauthorized")
            {
                Console.WriteLine($"{httpResponseMessage.StatusCode}");
                throw new ArgumentException($"Error Message: {response?.error.message}");
            }
            else if (httpResponseMessage.StatusCode.ToString() == "Forbidden")
            {
                Console.WriteLine($"{httpResponseMessage.StatusCode}");
                throw new ArgumentException($"Error Message: Contributor? {response?.error.message}");
            }
            else if (httpResponseMessage.StatusCode.ToString() == "BadRequest")
            {
                Console.WriteLine($"{httpResponseMessage.StatusCode}");
                throw new ArgumentException($"Error Message: {response?.error.message}");
            }
            else {
                Console.WriteLine($"{httpResponseMessage.StatusCode}");
                Console.WriteLine($"Added to {KvName}: " + SecretNameX);
                return $"secretUriWithVersion: {response?.properties.secretUriWithVersion}";
            }
        }
    }
}
