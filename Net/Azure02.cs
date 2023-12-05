///Program.se
namespace json02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://management.azure.com/subscriptions/2d9f44ea-e3df-4ea1-b956-8c7a43b119a0/resourceGroups/rg-owner?api-version=2022-09-01";
            string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lNDRhNmZlMy01NDNlLTQ3YzEtYThlNi0wYWIyODQxMjI3YzgvIiwiaWF0IjoxNzAxNzQ5NjAwLCJuYmYiOjE3MDE3NDk2MDAsImV4cCI6MTcwMTc1MzcxNCwiYWNyIjoiMSIsImFpbyI6IkFZUUFlLzhWQUFBQTJoQ0Q4SSt0SVVGQUZ3eG1KSHNqRFB3L0FDWEJiWllNK2c1Nm1rdmRHMDVwZW16clYvdWRpV29iaGRKS2NXREo3b1l4Qm9NTWhsb3Z2WjZCRDZaNDFaWGltNnA2Z281UGZHaSt0bHZOWTJDNTNPOWZZcUlDaVJrSkI1aVRsekNaZDNxdkx4cjZNcGVlT3ZNbnVyWFQ5R2dOQWtFNDZ4cEdEZkdmRmtmNkJUWT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDFDMTQzNENFNiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOTUwYTI1OC0yMjdiLTRlMzEtYTljZi03MTc0OTU5NDVmYzIiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6Imthcm9sLnNla0BvdXRsb29rLmNvbSIsImZhbWlseV9uYW1lIjoiUyIsImdpdmVuX25hbWUiOiJLYXJvbCIsImdyb3VwcyI6WyIyODgyNjFhNi00MjZkLTQ0NmYtYmQzMi1iYzI3NjJhNTY1YzkiXSwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODguMTUwLjk2LjQ4IiwibmFtZSI6Ikthcm9sIFMiLCJvaWQiOiJkNTU4NDZkYy04ZDg4LTRiMjMtYjFlMi04NGMyMGIwM2I5OGEiLCJwdWlkIjoiMTAwMzIwMDE5QTYxNEQ1RiIsInJoIjoiMC5BVTRBNDI5SzVENVV3VWVvNWdxeWhCSW55RVpJZjNrQXV0ZFB1a1Bhd2ZqMk1CTU9BYzguIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiNTRWLVpIdlZsaExwNVlocnJ0TXNiRnRBSUV0aGc4eUo0dEhuY1paeS16SSIsInRpZCI6ImU0NGE2ZmUzLTU0M2UtNDdjMS1hOGU2LTBhYjI4NDEyMjdjOCIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20ja2Fyb2wuc2VrQG91dGxvb2suY29tIiwidXRpIjoiMEUydUNWcGpJMHVSV05yOVEyOUJBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19jYWUiOiIxIiwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfdGNkdCI6MTYzNDgwNzg2MX0.I9d742_VVbHErI3BKI-UfLNkukbkvogHwHSkoUy26RRMmS14q1BC3MXaEIjf_W-EPck49Az1pQADn0azZV31qB4Y0o3SY4etLHQe_RsYO8rPkL3LC3U1OEC-lWRG6qdaJF7fxYLYkrBdsDjmBaX9kY5lcuwPT-07_OpzoP2Z9wwss3ywOMkELXEG2zs0yDwx-3bYN3m5XEUwX8jUIiZ5Br1y9_xkTvlNW4QUEMf7J2a4aokTJ7LLYIs0dz3VQVW0gYBOL9_cDhbD3UhNvHzJn0sOdViNDAucBLTD9Us-mazhv1eSVy2Kh2Pjzi7Vc7v62FDuao0xJe0L-a_4G3JmIg";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            
            try
            {
                //httpRequest.Method = "PATCH"; //FOR
                httpRequest.Accept = "application/json";
                httpRequest.Headers["Authorization"] = "Bearer " + AccessToken;
                //GET request
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    //Parse JSON
                    dynamic azure = JObject.Parse(result);
                    //Get info v1
                    string id = azure.id;
                    Console.WriteLine(id);
                    string location = azure.location;
                    Console.WriteLine(location);
                    //Get info v2
                    MyAzureProp myRg = new MyAzureProp();
                    Tags myTag = new Tags();
                    myRg.id = azure.id;
                    myRg.location = azure.location;
                    myRg.name = azure.name;
                    myTag.SYSTEM = azure.tags.SYSTEM;
                    Console.WriteLine("Name: {0}, Location: {1}, Tags: {2}", myRg.name, myRg.location, myTag.SYSTEM);
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
///MyAzureProp.cs
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
