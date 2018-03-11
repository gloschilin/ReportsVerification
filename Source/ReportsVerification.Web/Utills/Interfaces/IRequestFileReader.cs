﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

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
        Task<bool> Read(HttpRequestMessage request, Action<UploadFileInfo> contentHandler);

        /// <summary>
        /// Метод читает файлы из папки на сервере
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contentHandler"></param>
        /// <returns></returns>
        bool Read(string path, Action<UploadFileInfo> contentHandler);
    }
}
