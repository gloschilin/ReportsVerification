using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Filters;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Services.Interfaces;
using ReportsVerification.Web.Utills;
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
        public async Task<HttpResponseMessage> Upload(Guid sessionId)
        {
            var uploadResult = await _requestFileReader.Read(Request,
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

        public ReportTypes[] NullReportDates { get; }
            = {
                ReportTypes.PurchasesBookNds,
                ReportTypes.SalesBookNds
            };

        /// <summary>
        /// Получить загруженные отечты пользвателем
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("~/api/sessions/{sessionId}/reports"), HttpGet]
        public IEnumerable<ReportInfo> GetReports(Guid sessionId, ReportRequestType type)
        {
            var result = (type == ReportRequestType.Exists
                ? _reportsService.GetReports(sessionId)
                : _reportsService.GetMissingReports(sessionId)).ToList();

            foreach (var info in result.Where(e=> NullReportDates.Contains(e.Type)))
            {
                var i1 = info as ReportInfoRevistion<DateOfMonth>;
                var i2 = info as ReportInfoRevistion<DateOfQuarter>;

                if (i1 != null)
                {
                    i1.ReportPeriod = null;
                }

                if (i2 != null)
                {
                    i2.ReportPeriod = null;
                }
            }

            return result;
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
