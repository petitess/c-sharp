using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpsgenieDstny
{
    internal class KeyVaultSecret
    {
        public async Task<string> GetSecret(string kvName, string secretName)
        {
            var kvUri = $"https://{kvName}.vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync(secretName);

            return secret.Value.Value;
        }
    }
}
