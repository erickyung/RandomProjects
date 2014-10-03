using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;


namespace ScreenScraping
{
    public class HttpRetriever
    {
        private CookieContainer _cookies = new CookieContainer();

        public byte[] PostMultiPart(string url, string boundary, byte[] data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            req.CookieContainer = _cookies;

            // post data
            using (Stream req_stream = req.GetRequestStream())
            {
                req_stream.Write(data, 0, data.Length);
                req_stream.Flush();
            }

            return GetData(req);
        }

        public byte[] Post(string url, Dictionary<string, string> data)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.CookieContainer = _cookies;

            // build data string
            string postData = "";
            foreach (string key in data.Keys)
            {
                if (!string.IsNullOrEmpty(postData)) postData += "&";

                postData += string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(data[key]));
            }

            // post data
            using (Stream req_stream = req.GetRequestStream())
            {
                using (StreamWriter sw = new StreamWriter(req_stream))
                {
                    sw.Write(postData);
                    sw.Flush();
                }
            }

            return GetData(req);
        }

        public byte[] Get(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.CookieContainer = _cookies;

            return GetData(req);
        }

        private byte[] GetData(HttpWebRequest req)
        {
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //PrintHeaders(resp);
            
            byte[] buffer = null;
            List<byte> list = new List<byte>();
            using (Stream resp_stream = resp.GetResponseStream())
            {
                byte[] abyte = new byte[1];
                while (resp_stream.Read(abyte, 0, abyte.Length) != 0)
                {
                    list.Add(abyte[0]);
                }
            }

            if (list.Count > 0)
            {
                buffer = list.ToArray();
            }

            return buffer;
        }

        private void PrintHeaders(HttpWebResponse resp)
        {
            Console.WriteLine("Status Code: {0}, for Url: {1}", resp.StatusCode, resp.ResponseUri.AbsoluteUri);
            WebHeaderCollection coll = resp.Headers;
            for (int i = 0; i < coll.Count; i++)
            {
                Console.WriteLine("Header:{0}:{1}", coll.AllKeys[i], coll[i]);
            }
            Console.WriteLine();
        }
    }
}
