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
        public bool Read(HttpRequestMessage request, 
            Action<UploadFileInfo> contentHandler)
        {
            var result = true;
            if (!request.Content.IsMimeMultipartContent())
            {
                return false;
            }

            var provider = new MultipartMemoryStreamProvider();
            request.Content.ReadAsMultipartAsync(provider);
            foreach (var contentInfo in provider.Contents.Select(contentInfo=> contentInfo))
            {
                var fileStream = contentInfo.ReadAsStreamAsync().Result;
                fileStream.Position = 0;
                string content;
                using (var reader = new StreamReader(fileStream, Encoding.GetEncoding("windows-1251")))
                {
                    content = reader.ReadToEnd();
                }
                var fileName = contentInfo.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                var uploadFileInfo = new UploadFileInfo(fileName, content);

                try
                {
                    contentHandler(uploadFileInfo);
                }
                catch (Exception ex)
                {
                    uploadFileInfo.SetError(ex.Message);
                    contentHandler(uploadFileInfo);
                    result = false;
                }
            }

            return result;
        }

        public bool Read(string path, Action<UploadFileInfo> contentHandler)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }

            var files = Directory.GetFiles(path);
            var result = true;
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var content = File.ReadAllText(file, Encoding.GetEncoding("windows-1251"));
                var info = new UploadFileInfo(fileInfo.Name, content);
                try
                {
                    contentHandler(info);
                }
                catch (Exception ex)
                {
                    info.SetError(ex.Message);
                    contentHandler(info);
                    result = false;
                }
            }

            return result;
        }
    }
}