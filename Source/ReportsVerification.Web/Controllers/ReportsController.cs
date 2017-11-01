using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Utills.Attributes;
using ReportsVerification.Web.Utills.Interfaces;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Обработка файлов отчета
    /// </summary>
    [ControllerSettings(allowCamelCase: true)]
    [CheckSessionActionFilter]
    public class ReportsController : ApiController
    {
        private readonly IRequestFileReader _requestFileReader;
        private readonly IReportRepository _reportRepository;
        private readonly IReportFactory _reportFactory;

        public ReportsController(
            IRequestFileReader requestFileReader, 
            IReportRepository reportRepository,
            IReportFactory reportFactory)
        {
            _requestFileReader = requestFileReader;
            _reportRepository = reportRepository;
            _reportFactory = reportFactory;
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
            var exisisReports = _reportRepository.GetList(sessionId);

            return type == ReportRequestType.Exists 
                ? GetExistsReports(exisisReports) 
                : GetMissingReports(exisisReports);
        }

        private IEnumerable<ReportInfo> GetMissingReports(IEnumerable<Report> exisisReports)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создать существубющие отчеты
        /// </summary>
        /// <param name="exisisReports"></param>
        /// <returns></returns>
        private static IEnumerable<ReportInfo> GetExistsReports(IEnumerable<Report> exisisReports)
        {
            var result = exisisReports.Select(report => report.GetReportInfo());
            return result.ToList();
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
                var xmlContent = XDocument.Parse(fileInfo.Content);
                var report = _reportFactory.GetReport(xmlContent);
                _reportRepository.Save(sessionId, fileInfo.FileName, report);
                return;
            }
            
            _reportRepository.SaveWrongReport(sessionId, fileInfo.FileName, fileInfo.ErrorMessage, fileInfo.Content);
        }
    }
}
