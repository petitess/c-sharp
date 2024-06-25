using System.Text;
using Newtonsoft.Json;

namespace SetSecrets
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string GithubPat = "github_pat_11AWLQFRxxxx";
            string GithubOwner = "petitess";
            string GithubRepo = "yaml";
            string GithubUrl = $"https://api.github.com/repos/{GithubOwner}/{GithubRepo}/actions/secrets/public-key";
            string GithubSecretName = "my_github_secret";
            string GithubSecretValue = "123abc";

            Console.WriteLine("URL: " + GithubUrl);
            //GET public-key
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.raw+json");
            httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "user");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GithubPat);
            var httpResponseKey = await httpClient.GetAsync(GithubUrl);

            var jsonResultKey = await httpResponseKey.Content.ReadAsStringAsync();
            dynamic? jsonKey = JsonConvert.DeserializeObject(jsonResultKey);
            var key = jsonKey?.key;
            var keyId = jsonKey?.key_id;
            Console.WriteLine("public-key: " + key);
            //Encrypt the secret
            var secretValue = System.Text.Encoding.UTF8.GetBytes(GithubSecretValue);
            var publicKey = Convert.FromBase64String($"{key}");
            var sealedSecret = Sodium.SealedPublicKeyBox.Create(secretValue, publicKey);
            Console.WriteLine(Convert.ToBase64String(sealedSecret));
            //Create a github secret
            string GithubUrlSecret = $"https://api.github.com/repos/{GithubOwner}/{GithubRepo}/actions/secrets/{GithubSecretName}";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(new
            {
                encrypted_value = sealedSecret,
                key_id = keyId

            }), Encoding.UTF8, "application/json");

            var httpResponseSecret = await httpClient.PutAsync(GithubUrlSecret, jsonContent);
            var jsonResultSecret = await httpResponseSecret.Content.ReadAsStringAsync();
            dynamic? jsonSecret = JsonConvert.DeserializeObject(jsonResultSecret);
            Console.WriteLine(jsonSecret);
        }
    }
}
