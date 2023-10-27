using System;
using System.IO;
using System.Net;

namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Net
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://learn.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadstring?view=net-7.0");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //System.IO
            File.WriteAllText(docPath + "\\myTest.txt", reply);
            
            Console.WriteLine(reply);
            Console.ReadLine();

        }
    }
}
