### Managed Identity / Personal account
```cs
AccessToken token =
                await new DefaultAzureCredential()
                .GetTokenAsync(
                    new TokenRequestContext(
            new[] { "https://management.azure.com/.default" }
            ));
```

### App registration
```cs
string tenantId = "xxx";
string clientId = "xxx";
string clientSecret = "xxx";
var _scopes = new string[] { "https://management.azure.com/.default" };
var _msalClent = ConfidentialClientApplicationBuilder
    .Create(clientId)
    .WithClientSecret(clientSecret)
    .WithAuthority(AadAuthorityAudience.AzureAdMyOrg, true)
    .WithTenantId(tenantId)
    .Build();
var authResult = await _msalClent
    .AcquireTokenForClient(_scopes)
    .WithForceRefresh(true)
    .ExecuteAsync();

var accessToken = authResult.AccessToken;
```
https://anoopt.medium.com/few-ways-of-obtaining-access-token-in-azure-application-to-application-authentication-40a9473a2dde
