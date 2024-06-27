Hashtable? GithubSecretsToCreate = new Hashtable();

GithubSecretsToCreate?.Add(GithubSecretName, GithubSecretValue);
GithubSecretsToCreate?.Add("GithubSecretName", "GithubSecretValue");

foreach (DictionaryEntry  s in GithubSecretsToCreate)
{

    Console.WriteLine(s.Key + ":" + s.Value);
}
