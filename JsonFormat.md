```cs
var opsgenieTId = (HttpWebRequest)WebRequest.CreateHttp(opsgenieUrl + $"/alerts/{alertId}/details");
opsgenieTId.Method = "POST";
opsgenieTId.Headers["Authorization"] = "GenieKey " + opsgenieApiKey;
opsgenieTId.ContentType = "application/json";
var streamWriter = new StreamWriter(opsgenieTId.GetRequestStream());
string opsgenieJson = @"
                    {
                    ""details"": {
                            ""TicketId"": ""123""
                          }
                    }
                    ";
streamWriter.Write(opsgenieJson);
streamWriter.Flush();
var responseOpsgenie = (HttpWebResponse)opsgenieTId.GetResponse();
```
```cs
var opsgenieTId = (HttpWebRequest)WebRequest.CreateHttp(opsgenieUrl + $"/alerts/{alertId}/details");
opsgenieTId.Method = "POST";
opsgenieTId.Headers["Authorization"] = "GenieKey " + opsgenieApiKey;
opsgenieTId.ContentType = "application/json";
var streamWriter = new StreamWriter(opsgenieTId.GetRequestStream());
string opsgenieJson = "{ \"details\": { \"TicketId\": \"TicketId\" } }";
streamWriter.Write(opsgenieJson);
streamWriter.Flush();
var responseOpsgenie = (HttpWebResponse)opsgenieTId.GetResponse();
```
```cs
var opsgenieTId = (HttpWebRequest)WebRequest.CreateHttp(opsgenieUrl + $"/alerts/{alertId}/details");
opsgenieTId.Method = "POST";
opsgenieTId.Headers["Authorization"] = "GenieKey " + opsgenieApiKey;
opsgenieTId.ContentType = "application/json";
var streamWriter = new StreamWriter(opsgenieTId.GetRequestStream());
var opsgenieJson = JObject.FromObject(new
{
    details = new { TicketId = "123412" }
});
streamWriter.Write(opsgenieJson);
streamWriter.Flush();
var responseOpsgenie = (HttpWebResponse)opsgenieTId.GetResponse();
```
