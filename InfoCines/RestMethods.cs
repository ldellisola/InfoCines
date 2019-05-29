using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace RestMethods
{
    public class RestMethods
    {
        public RestMethods(string baseAddress, string path)
        {

            request = (HttpWebRequest)WebRequest.Create(baseAddress + path);
        }

        public RestMethods(string address)
        {

            request = (HttpWebRequest)WebRequest.Create(address);
        }

        private HttpWebRequest request;
        private byte[] RequestContent;

        private string MakeRequest()
        {
            try
            {
                Stream datastream;
                if (request.Method != "GET" && request.Method != "DELETE")
                {
                    datastream = request.GetRequestStream();
                    datastream.Write(RequestContent, 0, RequestContent.Length);

                    datastream.Close();
                }

                WebResponse response = request.GetResponse();
                datastream = response.GetResponseStream();
                StreamReader reader = new StreamReader(datastream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                datastream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void LoadContent(string content)
        {
            RequestContent = Encoding.UTF8.GetBytes(content);
            request.ContentLength = RequestContent.Length;
        }

        public T Get<T>()
            where T : new()
        {

            string content = Get();
            T obj = default(T);

            if (content != null)
            {
                obj = JsonConvert.DeserializeObject<T>(content);
            }

            return obj;
        }
        public string Get()
        {

            request.Method = "GET";

            return MakeRequest();

        }
        public string Post(object content)
        {
            string contentA = JsonConvert.SerializeObject(content);

            LoadContent(contentA);

            request.Method = "POST";

            return MakeRequest();
        }
        public T Post<T>(object content)
            where T : new()
        {
            string response = Post(content);

            T obj = default(T);

            if (response != null)
            {
                obj = JsonConvert.DeserializeObject<T>(response);
            }

            return obj;
        }

        public string Delete()
        {
            request.Method = "DELETE";

            return MakeRequest();
        }
        public T Delete<T>()
            where T : new()
        {

            string content = Delete();

            T obj = default(T);

            if (content != null)
            {
                obj = JsonConvert.DeserializeObject<T>(content);
            }

            return obj;
        }

        public string Put(object obj)
        {

            string content = JsonConvert.SerializeObject(obj);

            LoadContent(content);

            request.Method = "PUT";

            return MakeRequest();
        }
        public T Put<T>(object obj)
            where T : new()
        {

            string response = Put(obj);

            T objResponse = default(T);

            if (response != null)
            {
                objResponse = JsonConvert.DeserializeObject<T>(response);
            }

            return objResponse;
        }

    }


}
