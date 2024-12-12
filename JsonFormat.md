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
```cs
List<dynamic> dyn = new List<dynamic>
{
        new { TicketId = "secret1", Ticket = "2024" },
        new { TicketId = "secret2", Ticket = "2025" },
        new { TicketId = "secret3", Ticket = "2026" },
};
```
```cs
JObject opsgenieJson = JObject.FromObject(new
{
    details = new { TicketId = "secret1", Ticket = "2025" },
    prop = new { TicketId = "secrt2", Ticket = "2026" },
    mob = new { TicketId = "secret3", Ticket = "2027" }

});
```
```cs
JArray array = JArray.FromObject(
new
{
    details = new { TicketId = "123412", Ticket = "2354" },
    prop = new { TicketId = "123412", Ticket = "2354" }
});
```
