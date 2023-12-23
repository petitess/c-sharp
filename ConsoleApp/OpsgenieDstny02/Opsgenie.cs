using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace OpsgenieDstny
{
    internal class Opsgenie
    {
        public string GetOpsgenieNextOnCallUser(string apiKeyOpsgenie)
        {
            //GET Opsgenie info
            string schedule = "Beredskap_schedule";
            string urlOpsgenie = $"https://api.opsgenie.com/v2/schedules/{schedule}/next-on-calls?scheduleIdentifierType=name";
            var clientOpsgenie = (HttpWebRequest)WebRequest.Create(urlOpsgenie);
            clientOpsgenie.Accept = "application/json";
            clientOpsgenie.Headers["Authorization"] = "GenieKey " + apiKeyOpsgenie;
            clientOpsgenie.ContentType = "application/json";
            var responseOpsgenie = (HttpWebResponse)clientOpsgenie.GetResponse();
            //Parse JSON
            var streamOpsgenie = new StreamReader(responseOpsgenie.GetResponseStream());
            dynamic dataOpsgenie = JObject.Parse(streamOpsgenie.ReadToEnd());
            //GET NextOnCall user
            string nextOnCall = dataOpsgenie.data.exactNextOnCallRecipients[0].name;

            return nextOnCall;
        }

    }
}
