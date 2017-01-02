using System;
using System.IO;
using System.Net;

namespace Arlanet.CopernicaNET.Utils
{
    using Arlanet.CopernicaNET.Configuration;

    public static class HttpRequest
    {
        #region Class Variables
        private static readonly Uri BaseAddress = new Uri(CopernicaSettings.Settings.ApiUrl);
        #endregion

        #region Public Methods

        public static HttpWebResponse Post(string posturl, string jsoninput)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseAddress + posturl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsoninput);
                streamWriter.Flush();
                streamWriter.Close();
                return (HttpWebResponse)httpWebRequest.GetResponse();
            }   
        }

        public static string Get(string geturl)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseAddress + geturl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                var response = (HttpWebResponse) httpWebRequest.GetResponse();
                string text = "";
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                return text;
            }
            catch (Exception ex)
            {
                throw new CopernicaException("Unable to retrieve data. Make sure the access token is correct.", ex);
            }
        }

        public static HttpWebResponse Put(string posturl, string jsoninput)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseAddress + posturl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsoninput);
                streamWriter.Flush();
                streamWriter.Close();

                return (HttpWebResponse)httpWebRequest.GetResponse();
            }
        }

        public static HttpWebResponse Delete(string posturl)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseAddress + posturl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        #endregion
    }
}
