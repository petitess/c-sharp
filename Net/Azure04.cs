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
            string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lNDRhNmZlMy01NDNlLTQ3YzEtYThlNi0wYWIyODQxMjI3YzgvIiwiaWF0IjoxNzAxOTY2NzQ0LCJuYmYiOjE3MDE5NjY3NDQsImV4cCI6MTcwMTk3MTg2MywiYWNyIjoiMSIsImFpbyI6IkFZUUFlLzhWQUFBQTZ0Sy9nRWRROTNyTWdmN1RmYWNRTlQvdzBUcWYyeDRuOTBrdStLYzd0MnUrbE0yWnR2eWppMG9pVDJUeXRxcmh1ZFRQd1VlWUcvTUx2Vk9GZm1YZytHZnQ3cnVmeStlT3U0eUhKVGc3Snd1MEF5K0swWEd4em1qRTUwQ1Y2VHBGRDc2RVNUOVRQRFRyUG9YZ3FZR0YvK2F4WnZCcjZVUnc4UExmOUhvVGVxTT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDFDMTQzNENFNiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOTUwYTI1OC0yMjdiLTRlMzEtYTljZi03MTc0OTU5NDVmYzIiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6Imthcm9sLnNla0BvdXRsb29rLmNvbSIsImZhbWlseV9uYW1lIjoiUyIsImdpdmVuX25hbWUiOiJLYXJvbCIsImdyb3VwcyI6WyIyODgyNjFhNi00MjZkLTQ0NmYtYmQzMi1iYzI3NjJhNTY1YzkiXSwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODguMTUwLjk2LjQ4IiwibmFtZSI6Ikthcm9sIFMiLCJvaWQiOiJkNTU4NDZkYy04ZDg4LTRiMjMtYjFlMi04NGMyMGIwM2I5OGEiLCJwdWlkIjoiMTAwMzIwMDE5QTYxNEQ1RiIsInJoIjoiMC5BVTRBNDI5SzVENVV3VWVvNWdxeWhCSW55RVpJZjNrQXV0ZFB1a1Bhd2ZqMk1CTU9BYzguIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiNTRWLVpIdlZsaExwNVlocnJ0TXNiRnRBSUV0aGc4eUo0dEhuY1paeS16SSIsInRpZCI6ImU0NGE2ZmUzLTU0M2UtNDdjMS1hOGU2LTBhYjI4NDEyMjdjOCIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20ja2Fyb2wuc2VrQG91dGxvb2suY29tIiwidXRpIjoieGI2UVJFaTkxMDI4UnJPOU1iczVBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19jYWUiOiIxIiwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfdGNkdCI6MTYzNDgwNzg2MX0.pWggnimO_yAR2c1C1HODcBjXwOnTWAk064-AjXxyOgfncZJbO5f1ge-UBw6Wc8kDtYsTTN48x5Ye10laY9G6DFBgyK4BQYUspz0HpSOMAgHoXlEB2P3Lxtr5CZIvl7Y43YXwxcKErNA-5cClYR14w9IlGqsV0YJs9l6yquJ5P-v_R_8J-PScYcFlB48Ssqtn2IbwqiuKS4rN5mzgFic-XJVDioKNO-jM1z3tozMcCF05yVmtjUKXs929OUbKUrG1jgG3Dk8L4mHwuCJAQVQf2R3tkqDNuFQ8pN9nEBh9TFEK3hhXibVJGAKqdT2krRrKFhnQTM-312A_U_KungS44Q";
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
                    dynamic jsonObj = JsonConvert.DeserializeObject(result);
                    jsonObj["tags"]["SYSTEM"] = "ACCESS";
                    jsonObj.Remove("properties");
                    Console.WriteLine("New value: " + jsonObj);
                    //Convert Json to String
                    string stringJson = jsonObj.ToString(); 
                    /////PATCH
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
                    var byteArrayx = Encoding.ASCII.GetBytes(stringJson);

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
