using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace azure01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string secretName = "secret01";
            var keyVaultName = "kv-standard-01";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");
        }
    }
}
