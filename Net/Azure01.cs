namespace json02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://management.azure.com/subscriptions/2d9f44ea-e3df-4ea1-b956-8c7a43b119a0/resourceGroups/rg-xxx?api-version=2022-09-01";
            string AccessToken = "xGciOiJSUzI1NiIsIng1dCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSIsImtpZCI6IlQxU3QtZExUdnlXUmd4Ql82NzZ1OGtyWFMtSSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lNDRhNmZlMy01NDNlLTQ3YzEtYThlNi0wYWIyODQxMjI3YzgvIiwiaWF0IjoxNzAxNzA3ODc0LCJuYmYiOjE3MDE3MDc4NzQsImV4cCI6MTcwMTcxMzAyOCwiYWNyIjoiMSIsImFpbyI6IkFZUUFlLzhWQUFBQVdiSWo3RnBWcStSSkpCWXRXQlNkN0xwa1drTlRTK2dlMFJRMzM4RE1lWUdWazgvNFdESXhVZmVyVXl5ZEdqSXZIU0xOaHJ0alJGaER4a0RHc0o1OUlGUlhqaFdLaGpYbXp5cVdoNnBVZHlyYm9RbGlmcDFZdmpYcDNZckt0OHE1dTFNbWE4aFY4bzF3clhtNU9QZVVpNjBmcUFqVDFlZVBDWWlobXFsNXdKQT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwMzQwMDFDMTQzNENFNiIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiIxOTUwYTI1OC0yMjdiLTRlMzEtYTljZi03MTc0OTU5NDVmYzIiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6Imthcm9sLnNla0BvdXRsb29rLmNvbSIsImZhbWlseV9uYW1lIjoiUyIsImdpdmVuX25hbWUiOiJLYXJvbCIsImdyb3VwcyI6WyIyODgyNjFhNi00MjZkLTQ0NmYtYmQzMi1iYzI3NjJhNTY1YzkiXSwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODguMTUwLjk2LjQ4IiwibmFtZSI6Ikthcm9sIFMiLCJvaWQiOiJkNTU4NDZkYy04ZDg4LTRiMjMtYjFlMi04NGMyMGIwM2I5OGEiLCJwdWlkIjoiMTAwMzIwMDE5QTYxNEQ1RiIsInJoIjoiMC5BVTRBNDI5SzVENVV3VWVvNWdxeWhCSW55RVpJZjNrQXV0ZFB1a1Bhd2ZqMk1CTU9BYzguIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiNTRWLVpIdlZsaExwNVlocnJ0TXNiRnRBSUV0aGc4eUo0dEhuY1paeS16SSIsInRpZCI6ImU0NGE2ZmUzLTU0M2UtNDdjMS1hOGU2LTBhYjI4NDEyMjdjOCIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20ja2Fyb2wuc2VrQG91dGxvb2suY29tIiwidXRpIjoiM0hBOTh5NFloVW1EeGROWURUYzZBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il0sInhtc19jYWUiOiIxIiwieG1zX2NjIjpbIkNQMSJdLCJ4bXNfdGNkdCI6MTYzNDgwNzg2MX0.AftXjMasRYBUzBvqVbCxxKt-F8zUxqjuxaFK0wR1mW89Nm8e6_a7l51gcO9MWJAVsONAiK3ojfUaY1qvk8ebdn8y2xB7bTI1YX1GG1rus6rt1xC0j9nL4PWOQH94_ifsdZNos_ck6OhIcKN9O585zuLpirgI-HKpx8S0GWX1dLwvtGFLJIRoqNiLx1-27znJNT11FC7o51epl-bzoLurJH4-o65UTDhPTC_XAXQn_hkq7pqfrqGHHpzWqeNeIumBOhtHtt4RPQLgEqw4I27dEuLAP1-e96Brmp_Xqa-alwOeUT31YLzG2w2Ld5bBMF4mQ-unK6vaKAKotATWO-2i1w";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer " + AccessToken;


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(httpResponse.StatusCode);
        }
    }
}
