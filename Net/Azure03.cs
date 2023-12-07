//Program.cs
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace json02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://management.azure.com/subscriptions/2d9f44ea-e3df-4ea1-b956-8c7a43b119a0/resourceGroups/rg-owner?api-version=2022-09-01";
            string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lNDRhNmZlMy01NDNlLTQ3YzEtYThlNi0wYWIyODQxMjI3YzgvIiwiaWF0IjoxNzAxOTI4Mzk5LCJuYmYiOjE3MDE5MjgzOTksImV4cCI6MTcwMTkzMzc3NiwiYWNyIjoiMSIsImFpbyI6IkFZUUFlLzhWQUFBQVJrKzEvVnFwS2d4blA4c3VBZk55b0lXby9sRlpOUFV5L0loYjNZcGRudFNQUHZ4WmZmK01GaEo0STRaaWdOcGpIL3NJdkZxWUg0VXBMYk4zbWxRMFdCbi9FcWI1dDdQZGVyZ1VOWnNNdWxqZStkb0swSnZITVRQcVBDeDZxMW5hKzRaUmcvbEw1TmE5NDU4ZGUwZUhRd3dPVDNqQmxsK2lLOVNWbXR3cTU5VT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDFDMTQzNENFNiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOTUwYTI1OC0yMjdiLTRlMzEtYTljZi03MTc0OTU5NDVmYzIiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6Imthcm9sLnNla0BvdXRsb29rLmNvbSIsImZhbWlseV9uYW1lIjoiUyIsImdpdmVuX25hbWUiOiJLYXJvbCIsImdyb3VwcyI6WyIyODgyNjFhNi00MjZkLTQ0NmYtYmQzMi1iYzI3NjJhNTY1YzkiXSwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODguMTUwLjk2LjQ4IiwibmFtZSI6Ikthcm9sIFMiLCJvaWQiOiJkNTU4NDZkYy04ZDg4LTRiMjMtYjFlMi04NGMyMGIwM2I5OGEiLCJwdWlkIjoiMTAwMzIwMDE5QTYxNEQ1RiIsInJoIjoiMC5BVTRBNDI5SzVENVV3VWVvNWdxeWhCSW55RVpJZjNrQXV0ZFB1a1Bhd2ZqMk1CTU9BYzguIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiNTRWLVpIdlZsaExwNVlocnJ0TXNiRnRBSUV0aGc4eUo0dEhuY1paeS16SSIsInRpZCI6ImU0NGE2ZmUzLTU0M2UtNDdjMS1hOGU2LTBhYjI4NDEyMjdjOCIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20ja2Fyb2wuc2VrQG91dGxvb2suY29tIiwidXRpIjoidnQxaGU5c1J1a20zd0prRnc0VU5BQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19jYWUiOiIxIiwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfdGNkdCI6MTYzNDgwNzg2MX0.oq7KlkJFKRpC3F6_EGgMdYi7qwdgZ0XYy327OuG45ff4uZCnF9iOs_z3GOJBeTBOgDtZKVgWvrWUsiw-8z0pr4lBFuRved4lUiX_40akDl8EUQrhjqkeq21m8J6eCo26NnJBvCksI6hUdb8anJnrSZKxCJQ5XStXrCI4QvM8oV6EmwqAYj72uQMFAlSrBgoa35dpeMlV9DKgqaQ_tQka290ecSx5QgLfxaja74_gEd06pJNkcbgYSKQaSxk5pQgakQtvgzyD8qeMyS60DS-3u0U6ToEBzJDnYqaEiD_w-vi0s9XBL--iDaWlVLZeuGm2FQsMaABpkCHewrWu03D4qQ";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            
            try
            {
                //httpRequest.Method = "PATCH"; //FOR
                httpRequest.Accept = "application/json";
                httpRequest.Headers["Authorization"] = "Bearer " + AccessToken;
                //GET request
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                Console.WriteLine("StatusCode: " + httpResponse.StatusCode + " Method " + httpResponse.Method);
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine("Result: ");
                    Console.WriteLine($"{result}");
                    //Parse JSON
                    dynamic azure = JObject.Parse(result);
                    //Get info v1
                    string id = azure.id;
                    //Console.WriteLine(id);
                    string location = azure.location;
                    //Console.WriteLine(location);
                    //Get info v2
                    MyAzureProp myRg = new MyAzureProp();
                    Tags myTag = new Tags();
                    myRg.id = azure.id;
                    myRg.location = azure.location;
                    myRg.name = azure.name;
                    myTag.SYSTEM = azure.tags.SYSTEM;
                    //Console.WriteLine("Name: {0}, Location: {1}, Tags: {2}", myRg.name, myRg.location, myTag.SYSTEM);
                    //Adjust JSON
                    azure.tags.SYSTEM = "EKO";
                    dynamic? jsonObj = JsonConvert.DeserializeObject(result);
                    jsonObj["tags"]["SYSTEM"] = "EKO";
                    Console.WriteLine("New value: " + jsonObj);

                    /*string jsonY = result.Replace("SONY", "EKO");
                    Console.WriteLine("Replace: \n" + jsonY);*/

                    /////PATCH
                    string myJson = @"
                    {
                        ""id"": ""/subscriptions/2d9f44ea-e3df-4ea1-b956-8c7a43b119a0/resourceGroups/rg-owner"",
                        ""name"": ""rg-owner"", 
                        ""type"": ""Microsoft.Resources/resourceGroups"",
                        ""location"": ""swedencentral"",
                        ""tags"": {
                            ""SYSTEM"" : ""ABCD"",
                            ""ENV"" :""DEV""
                        }
                    }
                    ";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var request = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString(url));
                    if (request == null)
                        throw new ApplicationException(string.Format("Could not create the httprequest from the url:{0}", url));

                    request.Method = "PATCH";
                    /*foreach (var item in headers)
                        request.Headers.Add(item.Key, item.Value);*/
                    request.Accept = "application/json";
                    request.Headers["Authorization"] = "Bearer " + AccessToken;

                    UTF8Encoding encodingx = new UTF8Encoding();
                    var byteArrayx = Encoding.ASCII.GetBytes(myJson);

                    request.ContentLength = byteArrayx.Length;
                    request.ContentType = "application/json";

                    Stream dataStreamx = request.GetRequestStream();
                    dataStreamx.Write(byteArrayx, 0, byteArrayx.Length);
                    dataStreamx.Close();

                    try
                    {
                        var responsex = (HttpWebResponse)request.GetResponse();
                        Console.WriteLine("GOOD: " + responsex.StatusCode);
                        //return new MyResponse(response);
                    }
                    catch (WebException ex)
                    {
                        HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;
                        Console.WriteLine("BAD: " + errorResponse.StatusDescription);
                        //return new MyResponse(errorResponse);
                    }

                }
                Console.WriteLine(httpResponse.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { httpRequest.Abort(); }
        }
    }
}
//MyAzureProp.cs
namespace json02
{
    public class MyAzureProp
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public Tags tags { get; set; }
        public Properties properties { get; set; }
    }
    public class Properties
    {
        public string provisioningState { get; set; }
    }

    public class Tags
    {
        public string SYSTEM { get; set; }
    }
}
