using System;
using System.Net.Http;

namespace ReportsVerification.Web.Utills.Interfaces
{
    /// <summary>
    /// Чтение файлов из текущего запроса
    /// </summary>
    public interface IRequestFileReader
    {
        /// <summary>
        /// Метод читает файлы из параметра request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="contentHandler"></param>
        /// <returns></returns>
        bool Read(HttpRequestMessage request, Action<string> contentHandler);
    }
}
