namespace json02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://management.azure.com/subscriptions/2d9f44ea-e3df-4ea1-b956-8c7a43b119a0/resourceGroups/rg-owner?api-version=2022-09-01";
            string AccessToken = "xxxxQiLCJhbGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lNDRhNmZlMy01NDNlLTQ3YzEtYThlNi0wYWIyODQxMjI3YzgvIiwiaWF0IjoxNzAxNzEyNjM5LCJuYmYiOjE3MDE3MTI2MzksImV4cCI6MTcwMTcxODI1MSwiYWNyIjoiMSIsImFpbyI6IkFZUUFlLzhWQUFBQXhhYzc4U3NnOHRyK25tbjRsaW9Uek56V25uMFdteThRcXN2azBacitnak5tUGJ5aDJ4ald0bHRrbG8zbEtWZUpaTVAzODdqcjdmcEZtQ20zS3RESjZyaUxxZ2RhTGZDQ2lMYzI5c25MdzM5S1NVc0dqejQ3V3NBUFdHcWZ2Yk9henRrSUhWRGt4dGV3em1tVGpFUjE5V2FudzRHWWpuQ0lxWDZuOEJ4R1ZXUT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDFDMTQzNENFNiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOTUwYTI1OC0yMjdiLTRlMzEtYTljZi03MTc0OTU5NDVmYzIiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6Imthcm9sLnNla0BvdXRsb29rLmNvbSIsImZhbWlseV9uYW1lIjoiUyIsImdpdmVuX25hbWUiOiJLYXJvbCIsImdyb3VwcyI6WyIyODgyNjFhNi00MjZkLTQ0NmYtYmQzMi1iYzI3NjJhNTY1YzkiXSwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODguMTUwLjk2LjQ4IiwibmFtZSI6Ikthcm9sIFMiLCJvaWQiOiJkNTU4NDZkYy04ZDg4LTRiMjMtYjFlMi04NGMyMGIwM2I5OGEiLCJwdWlkIjoiMTAwMzIwMDE5QTYxNEQ1RiIsInJoIjoiMC5BVTRBNDI5SzVENVV3VWVvNWdxeWhCSW55RVpJZjNrQXV0ZFB1a1Bhd2ZqMk1CTU9BYzguIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiNTRWLVpIdlZsaExwNVlocnJ0TXNiRnRBSUV0aGc4eUo0dEhuY1paeS16SSIsInRpZCI6ImU0NGE2ZmUzLTU0M2UtNDdjMS1hOGU2LTBhYjI4NDEyMjdjOCIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20ja2Fyb2wuc2VrQG91dGxvb2suY29tIiwidXRpIjoiQnhRLUZYV2lEVTZuYXVNSE1abzVBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19jYWUiOiIxIiwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfdGNkdCI6MTYzNDgwNzg2MX0.K_5r8wCa43_Be_1cIiLzX_QHqd7hyaQLpNHxFABEIClw6mOTROkkNRTNGsGZeiu9rMQQBx0zO6vX6v473GxQ-zELWzGi3yYgg_xAPtriFQ3LXu4rBao6EEHW2kdF5k1eAwV-acIO3vrcxBdAvUTCeqTamxAKoO0wn0uJLQB0ZDw9U-G9w-QGMyyIFHVWIBCe47dYFUlZklRf4o6o-ig0qgLtIhpYaT5XRoFI4TpKHYhtcXt1mLRLWaen6HWvKrCDm1S_ik9RTToGjrTaSVDYGkUPhoOdqi135yHgg4_JVT2s61KL5_sro0dMVmq6cdIlC7jHFrJfj8RZ8bQwFe5N4g";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
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
                string id = azure.id;
                Console.WriteLine(id);
                string location = azure.location;
                Console.WriteLine(location);
            }
            Console.WriteLine(httpResponse.StatusCode);
        }
    }
}
