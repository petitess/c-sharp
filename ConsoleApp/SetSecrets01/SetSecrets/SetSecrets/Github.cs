using Newtonsoft.Json;
using System.Text;

namespace SetSecrets
{
    internal class Github
    {
        public async Task<object> SetGithubSecret(string? GithubPat, string? GithubOwner, string? GithubRepo, string? GithubSecretName, string? GithubSecretValue)
        {
            Console.WriteLine("GITHUB SECRET: ");
            string? GithubSecretNameX = GithubSecretName?.Replace("-", "_").Replace(" ", "_").Replace("<div>", "").Replace("</div>", "");
            string? GithubUrl = $"https://api.github.com/repos/{GithubOwner}/{GithubRepo}/actions/secrets/public-key";

            //GET public-key
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.raw+json");
            httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "user");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GithubPat);
            var httpResponseKey = await httpClient.GetAsync(GithubUrl);
            if (httpResponseKey.StatusCode.ToString() == "OK")
            {
                var jsonResultKey = await httpResponseKey.Content.ReadAsStringAsync();
                dynamic? jsonKey = JsonConvert.DeserializeObject(jsonResultKey);
                var key = jsonKey?.key;
                var keyId = jsonKey?.key_id;
                Console.WriteLine("public-key: " + $"{key}".ToString().Substring(0,10) + "...");
                //Encrypt the secret
                var secretValue = GithubSecretValue != null ? System.Text.Encoding.UTF8.GetBytes(GithubSecretValue) : null;
                var publicKey = Convert.FromBase64String($"{key}");
                var sealedSecret = secretValue != null ? Sodium.SealedPublicKeyBox.Create(secretValue, publicKey): null;
                //Console.WriteLine(Convert.ToBase64String(sealedSecret));
                //Create a github secret
                string? GithubUrlSecret = $"https://api.github.com/repos/{GithubOwner}/{GithubRepo}/actions/secrets/{GithubSecretNameX}";
                Console.WriteLine("Github Url: " + GithubUrlSecret);
            
                var jsonContent = new StringContent(JsonConvert.SerializeObject(new
                {
                    encrypted_value = sealedSecret,
                    key_id = keyId

                }), Encoding.UTF8, "application/json");

                var httpResponseSecret = await httpClient.PutAsync(GithubUrlSecret, jsonContent);
                Console.WriteLine(httpResponseSecret.StatusCode.ToString());
                if (httpResponseSecret.StatusCode.ToString() == "NoContent") { Console.WriteLine($"OK"); } else { Console.WriteLine($"Not OK"); };
                var jsonResultSecret = await httpResponseSecret.Content.ReadAsStringAsync();
                dynamic? jsonSecret = JsonConvert.DeserializeObject(jsonResultSecret);
                return jsonSecret != null ? $"Added as Github Secret: {GithubSecretNameX}" : $"Updated Github Secret: {GithubSecretNameX}";
            }
            else
            {
                throw new ArgumentException($"Status Code : {httpResponseKey.StatusCode}");
            }
        }
        public async Task<object> SetGithubVariable(string? GithubPat, string? GithubOwner, string? GithubRepo, string? GithubVariableName, string? GithubVariableValue)
        {
            Console.WriteLine("GITHUB VARIABLE: ");
            string? GithubVariableNameX = GithubVariableName?.Replace("-", "_").Replace(" ", "_").Replace("<div>", "").Replace("</div>", "");
  
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.raw+json");
            httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "user");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GithubPat);
            //GET Variable
            string? GithubUrlVariableGet = $"https://api.github.com/repos/{GithubOwner}/{GithubRepo}/actions/variables/{GithubVariableNameX + "_URL"}";
            var httpResponseVariableGet = await httpClient.GetAsync(GithubUrlVariableGet);
            var returnObject = "";
 
            if (httpResponseVariableGet.StatusCode.ToString() == "OK")
            {
                Console.WriteLine($"Updating Variable: {GithubVariableNameX}");

                var jsonContentPatch = new StringContent(JsonConvert.SerializeObject(new
                {
                    name = GithubVariableNameX + "_URL",
                    value = GithubVariableValue

                }), Encoding.UTF8, "application/json");
                //Update Variable
                var httpResponseVariablePost = await httpClient.PatchAsync(GithubUrlVariableGet, jsonContentPatch);

                if (httpResponseVariablePost.StatusCode.ToString() == "NoContent")
                { Console.WriteLine($"OK"); }
                else { throw new ArgumentException($"Error : {httpResponseVariablePost}"); };

                returnObject = httpResponseVariablePost.StatusCode.ToString();
            }
            else 
            {
                Console.WriteLine($"Creating Variable: {GithubVariableNameX}");
                string? GithubUrlVariablePost = $"https://api.github.com/repos/{GithubOwner}/{GithubRepo}/actions/variables";
                Console.WriteLine("Github Url: " + GithubUrlVariablePost);

                var jsonContentPost = new StringContent(JsonConvert.SerializeObject(new
                {
                    name = GithubVariableNameX + "_URL",
                    value = GithubVariableValue

                }), Encoding.UTF8, "application/json");
                //Create Variable
                var httpResponseVariablePost = await httpClient.PostAsync(GithubUrlVariablePost, jsonContentPost);
                Console.WriteLine(httpResponseVariablePost.StatusCode);
                var jsonResultVariablePost = await httpResponseVariablePost.Content.ReadAsStringAsync();
                dynamic? jsonVariablePost = JsonConvert.DeserializeObject(jsonResultVariablePost);
                if (httpResponseVariablePost.StatusCode.ToString() == "Created")
                { Console.WriteLine($"OK"); }
                else { throw new ArgumentException($"Error : {jsonVariablePost?.message}"); };
                returnObject = jsonVariablePost != null ? $"Added as Github Variable: {GithubVariableNameX}" : $"Updated Github Variable: {GithubVariableNameX}";
            }
            return returnObject;

        }
    }
}
