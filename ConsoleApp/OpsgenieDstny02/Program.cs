using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace OpsgenieDstny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeyVaultSecret secret = new KeyVaultSecret();
            var apiKeyOpsgenie = (secret.GetSecret("kv-standard-01", "ApiKeyOpsgenie")).Result;
            var apiKeyDstny = (secret.GetSecret("kv-standard-01", "ApiKeyDstny")).Result;

            Opsgenie opsgenieUser = new Opsgenie();
            string nextOnCall = opsgenieUser.GetOpsgenieNextOnCallUser(apiKeyOpsgenie);

            Dstny dstny = new Dstny();
            dstny.LogoutDstnyUsers(apiKeyDstny);
            dstny.LoginDstnyUser(apiKeyDstny, nextOnCall);
        }
    }
}