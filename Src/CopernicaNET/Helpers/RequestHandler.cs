using System;
using System.IO;
using System.Net;
using Arlanet.CopernicaNET.Data;

namespace Arlanet.CopernicaNET.Helpers
{
    using Arlanet.CopernicaNET.Configuration;

    public static class RequestHandler
    {
        #region Class Variables

        private static readonly Uri BaseAddress = new Uri(CopernicaSettings.Settings.ApiUrl);

        #endregion


        #region Public Methods

        public static string Get(string geturl)
        {
            var httpWebRequest = CreateWebRequest(geturl, "GET");

            try
            {
                using (var response = httpWebRequest.GetResponse())
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CopernicaException("Unable to retrieve data. Make sure the access token is correct.", ex);
            }
        }

        public static HttpStatusCode Post(string posturl, string jsoninput)
        {
            using (var httpWebResponse = PostResponse(posturl, jsoninput))
            {
                return httpWebResponse.StatusCode;
            }
        }

        public static HttpWebResponse PostResponse(string posturl, string jsoninput)
        {
            return SendJson(posturl, "POST", jsoninput);
        }

        public static HttpStatusCode Put(string posturl, string jsoninput)
        {
            using (var httpWebResponse = PutResponse(posturl, jsoninput))
            {
                return httpWebResponse.StatusCode;
            }
        }

        public static HttpWebResponse PutResponse(string puturl, string jsoninput)
        {
            return SendJson(puturl, "PUT", jsoninput);
        }

        public static HttpStatusCode Delete(string deleteurl)
        {
            using (var httpWebResponse = DeleteResponse(deleteurl))
            {
                return httpWebResponse.StatusCode;
            }
        }

        public static HttpWebResponse DeleteResponse(string deleteurl)
        {
            var httpWebRequest = CreateWebRequest(deleteurl, "DELETE");
            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        private static HttpWebRequest CreateWebRequest(string url, string method)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseAddress + url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;

            return httpWebRequest;
        }

        private static HttpWebResponse SendJson(string url, string method, string jsoninput)
        {
            var httpWebRequest = CreateWebRequest(url, method);

            using (var requestStream = httpWebRequest.GetRequestStream())
            {
                using (var streamWriter = new StreamWriter(requestStream))
                {
                    streamWriter.Write(jsoninput);
                    streamWriter.Flush();
                    return (HttpWebResponse)httpWebRequest.GetResponse();
                }
            }
        }

        #endregion
    }
}