using System.Collections;

namespace SetSecrets
{
    internal class Program
    {
        //static void Main(string[] args)
        static void Main(string[] args)
        {
            ///PWSTATE INFO
            string? apiKey = Environment.GetEnvironmentVariable("API_KEY");
            string? pwdId1 = Environment.GetEnvironmentVariable("SECRET_1");
            string? pwdId2 = Environment.GetEnvironmentVariable("SECRET_2");
            string? pwdId3 = Environment.GetEnvironmentVariable("SECRET_3");
            string? pwdId4 = Environment.GetEnvironmentVariable("SECRET_4");
            string? pwdId5 = Environment.GetEnvironmentVariable("SECRET_5");
            ///GITHUB INFO, classic token with SSO, repo permission
            string? GithubPat = Environment.GetEnvironmentVariable("GH_PAT");
            string? GithubOwner = Environment.GetEnvironmentVariable("GITHUB_REPOSITORY_OWNER");
            string? GithubRepo = Environment.GetEnvironmentVariable("GH_REPO");
            ///Key Vault INFO
            string? AzToken = Environment.GetEnvironmentVariable("AZ_TOKEN");
            string? SubscriptionId = Environment.GetEnvironmentVariable("ARM_SUBSCRIPTION_ID");
            string? RgName = Environment.GetEnvironmentVariable("AZURE_RG_KV_NAME");
            string? KvName = Environment.GetEnvironmentVariable("AZURE_KV_NAME");
            //Condition
            string? AddGithubSecret = GithubRepo == "none" ? "false" : "true";
            string? AddKvSecret = KvName == "none" ? "false" : "true";
            Console.WriteLine($"Add to Github: {AddGithubSecret}\nAdd To Key Vault: {AddKvSecret}");

            PwState01 pwState = new PwState01();
            List<string>? passwordIds = new List<string>();

            if (pwdId1 != "") { passwordIds.Add(pwdId1 != null ? pwdId1 : ""); } else { pwdId1 = "";}
            if (pwdId2 != "") { passwordIds.Add(pwdId2 != null ? pwdId2 : ""); } else { pwdId2 = "";}
            if (pwdId3 != "") { passwordIds.Add(pwdId3 != null ? pwdId3 : ""); } else { pwdId3 = "";}
            if (pwdId4 != "") { passwordIds.Add(pwdId4 != null ? pwdId4 : ""); } else { pwdId4 = "";}
            if (pwdId5 != "") { passwordIds.Add(pwdId5 != null ? pwdId5 : ""); } else { pwdId5 = "";}

            Console.WriteLine("Number of Secrets: " + passwordIds.Count);

            Hashtable passwords = new Hashtable();

            foreach (string passwordId in passwordIds)
            {
                if (passwordId.Contains(":::")) 
                {
                    string id = passwordId.Split(":::")[0];
                    string query = passwordId.Split(":::")[1];

                    var values = pwState?.GetPassword(apiKey, id, query);

                    if (values != null)
                    {
                        foreach (DictionaryEntry value in values.Result)
                            passwords.Add(value.Key, value.Value);
                    }
                }
                else
                {
                    var values = pwState?.GetPassword(apiKey, passwordId);
                    if (values != null)
                    {
                        foreach (DictionaryEntry value in values.Result)
                            passwords.Add(value.Key, value.Value);
                    }
                }
            }

            Github setGhSec = new Github();
            if (Convert.ToBoolean(AddGithubSecret))
            {
                foreach (DictionaryEntry p in passwords)
                {
                    if (p.Value != null)
                    {
                        var gh = setGhSec?.SetGithubSecret(GithubPat, GithubOwner, GithubRepo, p.Key.ToString(), p.Value.ToString());
                        Console.WriteLine(gh?.Result);
                    }
                }
            }

            KeyVault setKvSec = new KeyVault();
            if (Convert.ToBoolean(AddKvSecret))
            {
                foreach (DictionaryEntry p in passwords)
                {
                    if (p.Value != null)
                    {
                        var kv = setKvSec?.SetKeyVaultSecret(AzToken, SubscriptionId, RgName, KvName, p.Key.ToString(), p.Value.ToString());
                        Console.WriteLine(kv?.Result);
                    }
                }
            }

            Hashtable urls = new Hashtable();

            foreach (string passwordId in passwordIds)
            {
                if (passwordId.Contains(":::"))
                {
                    string id = passwordId.Split(":::")[0];
                    string query = passwordId.Split(":::")[1];

                    var values = pwState?.GetUrl(apiKey, id, query);

                    if (values != null)
                    {
                        foreach (DictionaryEntry value in values.Result)
                            urls.Add(value.Key, value.Value);
                    }
                }
                else
                {
                    var values = pwState?.GetUrl(apiKey, passwordId);
                    if (values != null)
                    {
                        foreach (DictionaryEntry value in values.Result)
                            urls.Add(value.Key, value.Value);
                    }
                }
            }

            Github setGhVariable = new Github();
            if (Convert.ToBoolean(AddGithubSecret))
            {
                foreach (DictionaryEntry u in urls)
                {
                    if (u.Value != null)
                    {
                        var gh = setGhVariable?.SetGithubVariable(GithubPat, GithubOwner, GithubRepo, u.Key.ToString(), u.Value.ToString());
                        Console.WriteLine(gh?.Result);
                    }
                }
            }
        }
    }
}
