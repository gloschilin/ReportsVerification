using System;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace ReportsVerification.Web.Utills.Interfaces
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
            foreach (var content in provider.Contents.Select(file => file.ReadAsStringAsync().Result))
            {
                ThreadPool.QueueUserWorkItem(state => contentHandler(content));
            }

            return true;
        }

    }
}