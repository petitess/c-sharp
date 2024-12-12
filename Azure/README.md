### Azure Token
```cs
public async Task<string> GetAzToken()
             {
             AccessToken token =
             await new DefaultAzureCredential()
                .GetTokenAsync(
                new TokenRequestContext(
        new[] { "https://management.azure.com/.default" }
    ));

    return token.Token;
}
```
### Microsoft Graph Token
```cs
    public async Task<string> GetMgToken()
    {
        AccessToken token = await new ChainedTokenCredential(
         //new ManagedIdentityCredential() //For Managed Identity
         new EnvironmentCredential() //For Local Run, environment variables
        ).GetTokenAsync(
             new TokenRequestContext(
             new[] { "https://graph.microsoft.com/.default" }
             )
         ).ConfigureAwait(false);
        //Save these environment variables:
        //AZURE_TENANT_ID
        //AZURE_CLIENT_ID
        //AZURE_CLIENT_SECRET

        return token.Token;
    }

```
