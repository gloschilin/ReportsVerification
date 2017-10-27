using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Repositories;
using ReportsVerification.Web.Utills;
using ReportsVerification.Web.Utills.Interfaces;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Тип запроса на получение отчетов
    /// </summary>
    public enum ReportRequestType
    {
        /// <summary>
        /// Существующие (загруженные)
        /// </summary>
        Exists,

        /// <summary>
        /// Недостающие
        /// </summary>
        Missing
    }

    /// <summary>
    /// Обработка файлов отчета
    /// </summary>
    public class ReportsController : ApiController
    {
        private readonly IRequestFileReader _requestFileReader;
        private readonly IContentHandler _contentHandler;
        private readonly IReportRepository _reportRepository;

        public ReportsController(
            IRequestFileReader requestFileReader, 
            IContentHandler contentHandler,
            IReportRepository reportRepository)
        {
            _requestFileReader = requestFileReader;
            _contentHandler = contentHandler;
            _reportRepository = reportRepository;
        }

        /// <summary>
        /// Добавить отчет (загрузить файл)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/reports")]
        public HttpResponseMessage Upload([FromUri]Guid sessionId)
        {
            if (_requestFileReader.Read(Request, content => HandleFileContent(sessionId, content)))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }

            AppLog.Error("Неудалось получить XML из загружаемого файла");
            throw new HttpException((int)HttpStatusCode.BadRequest, "Не удалось загрузить файлы");
        }

        /// <summary>
        /// Получить загруженные отечты пользвателем
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="reportRequestType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/reports")]
        public IEnumerable<ReportInfo> GetReports([FromUri]Guid sessionId, ReportRequestType reportRequestType)
        {
            var exisisReports = _reportRepository.GetList(sessionId);

            return reportRequestType == ReportRequestType.Exists 
                ? GetExistsReports(sessionId, exisisReports) 
                : GetMissingReports(sessionId, exisisReports);
        }

        private IEnumerable<ReportInfo> GetMissingReports(Guid sessionId, IEnumerable<Report> exisisReports)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создать существубющие отчеты
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="exisisReports"></param>
        /// <returns></returns>
        private IEnumerable<ReportInfo> GetExistsReports(Guid sessionId, IEnumerable<Report> exisisReports)
        {
            var result = exisisReports.Select(report =>
            {
                ReportInfo reportInfo;
                _contentHandler.Handle(report.Content, out reportInfo);
                return reportInfo;
            });
            return result.ToList();
        }

        /// <summary>
        /// Обрабатываем полученный контект файла
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="fileContent"></param>
        private void HandleFileContent(Guid sessionId, string fileContent)
        {
            XDocument xmlContent;
            try
            {
                xmlContent = XDocument.Parse(fileContent);
            }
            catch (Exception ex)
            {
                AppLog.Error("Неудалось получить XML из загружаемого файла", ex);
                throw new HttpException((int)HttpStatusCode.BadRequest, 
                    "Ошибка при чтении файла. Контект файла не является XML");
            }

            ReportInfo reportInfo;
            if (!_contentHandler.Handle(xmlContent, out reportInfo))
            {
                const string message = "Неудалось обработать файл. Неизвестный тип отчета";
                AppLog.Error(message);
                throw new HttpException((int)HttpStatusCode.BadRequest, message);
            }

            var report = new Report(xmlContent);
            _reportRepository.Save(sessionId, report);
        }
    }
}
