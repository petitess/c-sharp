using System.Net;

namespace MyCodeLibrary01
{
    public class Scrape
    {
        public string ScrapeWebpage(string url)
        {
            return GetWebpage(url);
        }

        public string ScrapeWebpage(string url, string fliepath)
        {
            string reply = GetWebpage(url);

            File.WriteAllText(fliepath, reply);
            return reply;
        }

        private string GetWebpage(string url) //helper method
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
