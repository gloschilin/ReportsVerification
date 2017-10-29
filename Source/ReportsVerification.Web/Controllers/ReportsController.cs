using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Utills;
using ReportsVerification.Web.Utills.Interfaces;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Обработка файлов отчета
    /// </summary>
    public class ReportsController : ApiController
    {
        private readonly IRequestFileReader _requestFileReader;
        private readonly IReportInfoBuilder _reportInfoBuilder;
        private readonly IReportRepository _reportRepository;
        private readonly IReportFactory _reportFactory;

        public ReportsController(
            IRequestFileReader requestFileReader, 
            IReportInfoBuilder reportInfoBuilder,
            IReportRepository reportRepository,
            IReportFactory reportFactory)
        {
            _requestFileReader = requestFileReader;
            _reportInfoBuilder = reportInfoBuilder;
            _reportRepository = reportRepository;
            _reportFactory = reportFactory;
        }

        /// <summary>
        /// Добавить отчет (загрузить файл)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/sessions/{sessionId}/reports")]
        public HttpResponseMessage Upload(Guid sessionId)
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
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/sessions/{sessionId}/reports")]
        public IEnumerable<ReportInfo> GetReports(Guid sessionId, ReportRequestType type)
        {
            var exisisReports = _reportRepository.GetList(sessionId);

            return type == ReportRequestType.Exists 
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
            var result = exisisReports.Select(report => report.GetReportInfo(_reportInfoBuilder));
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

            try
            {
                var report = _reportFactory.GetReport(xmlContent);
                _reportRepository.Save(sessionId, report);
            }
            catch (Exception ex)
            {
                AppLog.Error($"Ошибка при создании экспемпляра отечта => {ex.Message}");
                throw new HttpException((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
