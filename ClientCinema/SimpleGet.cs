using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientCinema
{
    public static class SimpleGet
    {
        public static string Get(string request)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(request);
            myRequest.Method = "GET";
            using (WebResponse myResponse = myRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public static T GetJsonObject<T>(string request)
        {
            string s = Get(request);
            return JsonConvert.DeserializeObject<T>(s);
        }
        public static JToken GetJson(string request)
        {
            string s = Get(request);
            if (string.IsNullOrEmpty(s))
                return null;
            return JToken.Parse(s);
        }
        public static System.Xml.Linq.XDocument GetXml(string request)
        {
            string s = Get(request);
            return System.Xml.Linq.XDocument.Parse(s);
        }
    }
}
