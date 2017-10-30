using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using ReportsVerification.Web.Utills.Interfaces;

namespace ReportsVerification.Web.Utills
{
    public class RequestFileReader : IRequestFileReader
    {
        public bool Read(HttpRequestMessage request, Action<string> contentHandler)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                return false;
            }

            var provider = new MultipartMemoryStreamProvider();
            request.Content.ReadAsMultipartAsync(provider);
            foreach (var stream in provider.Contents.Select(file => file.ReadAsStreamAsync().Result))
            {
                stream.Position = 0;
                using (var reader = new StreamReader(stream, Encoding.GetEncoding("windows-1251")))
                {
                    var content = reader.ReadToEnd();
                    contentHandler(content);
                }   
            }

            return true;
        }

    }
}