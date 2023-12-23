using Newtonsoft.Json.Linq;
using System.Net;


namespace OpsgenieDstny
{
    internal class Dstny
    {
        string domainDstny = "xxxxit.se";
        string apiKeyUser = "a8105";
        string groupDstny = "82441";
        public void LogoutDstnyUsers(string apiKeyDstny)
        {
            //GET Dstny info
            string urlDstny = $"https://bc.dstny.se/api/user/acd-attendant-group/v1/{domainDstny}/{apiKeyUser}";
            var clientDstny = (HttpWebRequest)WebRequest.Create(urlDstny);
            clientDstny.Accept = "application/json";
            clientDstny.Headers["Authorization"] = "Bearer " + apiKeyDstny;
            clientDstny.ContentType = "application/json";
            var responseDstny = (HttpWebResponse)clientDstny.GetResponse();
            //Parse JSON
            var streamDstny = new StreamReader(responseDstny.GetResponseStream());
            dynamic dataDstny = JObject.Parse(streamDstny.ReadToEnd());
            //GET all users for ADC group
            var agentsDstny = dataDstny.groups[0].agents;
            //POST logout
            foreach (var agent in agentsDstny)
            {
                //POST logout all users
                string urlDstnyPostLogout = $"https://bc.dstny.se/api/user/acd-attendant-group/{domainDstny}/{apiKeyUser}/{groupDstny}/{domainDstny}/agents/{agent.id}?action=logout";
                var clientDstnyPostLogout = (HttpWebRequest)WebRequest.Create(urlDstnyPostLogout);
                clientDstnyPostLogout.Accept = "application/json";
                clientDstnyPostLogout.Headers["Authorization"] = "Bearer " + apiKeyDstny;
                clientDstnyPostLogout.ContentType = "application/json";
                clientDstnyPostLogout.Method = "POST";

                try
                {
                    var response = (HttpWebResponse)clientDstnyPostLogout.GetResponse();
                }
                catch (WebException ex)
                {
                    HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;
                }
            }
        }

        public void LoginDstnyUser(string apiKeyDstny, string userId)
        {
            string dstnyUserID = "";

            switch (userId)
            {
                case "x.sek@xxxx.se":
                    dstnyUserID = "a8105@xxxxit.se";
                    break;

                case "x.ljungstrom@xxxx.se":
                    dstnyUserID = "a8106@xxxxit.se";
                    break;

                case "x.sjoblom@xxxx.se":
                    dstnyUserID = "a8117@xxxxit.se";
                    break;

                case "x.bilger@xxxx.se":
                    dstnyUserID = "a8115@xxxxit.se";
                    break;

                case "x.torntorp@xxxx.se":
                    dstnyUserID = "a8121@xxxxit.se";
                    break;

                case "x.holm@xxxx.se":
                    dstnyUserID = "a0752@xxxxit.se";
                    break;

            }
            //POST login
            string urlDstnyPostLogin = $"https://bc.dstny.se/api/user/acd-attendant-group/{domainDstny}/{apiKeyUser}/{groupDstny}/{domainDstny}/agents/{dstnyUserID}?action=login";
            var clientDstnyPostLogin = (HttpWebRequest)WebRequest.Create(urlDstnyPostLogin);
            clientDstnyPostLogin.Accept = "application/json";
            clientDstnyPostLogin.Headers["Authorization"] = "Bearer " + apiKeyDstny;
            clientDstnyPostLogin.ContentType = "application/json";
            clientDstnyPostLogin.Method = "POST";
            try
            {
                var response = (HttpWebResponse)clientDstnyPostLogin.GetResponse();
            }
            catch (WebException ex)
            {
                HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;
            }
        }
    }
}
