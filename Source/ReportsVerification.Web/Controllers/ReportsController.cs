using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Filters;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Services.Interfaces;
using ReportsVerification.Web.Utills.Attributes;
using ReportsVerification.Web.Utills.Interfaces;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Обработка файлов отчета
    /// </summary>
    [ControllerSettings(allowCamelCase: true), AllowOptionsFilter]
    [CheckSessionActionFilter]
    public class ReportsController : ApiController
    {
        private readonly IRequestFileReader _requestFileReader;
        private readonly IReportsService _reportsService;

        public ReportsController(
            IRequestFileReader requestFileReader, 
            IReportsService reportsService)
        {
            _requestFileReader = requestFileReader;
            _reportsService = reportsService;
        }

        /// <summary>
        /// Добавить отчет (загрузить файл)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [Route("~/api/sessions/{sessionId}/reports"), HttpPost]
        public HttpResponseMessage Upload(Guid sessionId)
        {
            var uploadResult = _requestFileReader.Read(Request,
                content =>
                {
                    if (content?.Content == null)
                    {
                        return;
                    }

                    HandleFileContent(sessionId, content);
                });

            return uploadResult
                ? new HttpResponseMessage(HttpStatusCode.Created)
                : new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Route("~/api/sessions/{sessionId}/reports"), HttpPost]
        public HttpResponseMessage Upload(Guid sessionId, [FromUri]string path)
        {
            var uploadResult = _requestFileReader.Read(path,
                    content => HandleFileContent(sessionId, content));

            return uploadResult
                ? new HttpResponseMessage(HttpStatusCode.Created)
                : new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Получить загруженные отечты пользвателем
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("~/api/sessions/{sessionId}/reports"), HttpGet]
        public IEnumerable<ReportInfo> GetReports(Guid sessionId, ReportRequestType type)
        {
            return type == ReportRequestType.Exists
                ? _reportsService.GetReports(sessionId)
                : _reportsService.GetMissingReports(sessionId);
        }


        /// <summary>
        /// Обрабатываем полученный контект файла
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="fileInfo"></param>
        private void HandleFileContent(Guid sessionId, UploadFileInfo fileInfo)
        {
            if (fileInfo.IsValid())
            {
                _reportsService.Save(sessionId, fileInfo.FileName, fileInfo.Content);
                return;
            }

            _reportsService.SaveWrongReport(sessionId, fileInfo.FileName, fileInfo.Content, fileInfo.ErrorMessage);
        }
    }
}
