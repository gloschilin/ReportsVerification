using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportFactory _reportFactory;
        private readonly ISessionRepository _sessionRepository;
        private readonly IRecomendationsService _recomendationsService;

        public ReportsService(IReportRepository reportRepository, 
            IReportFactory reportFactory,
            ISessionRepository sessionRepository,
            IRecomendationsService recomendationsService)
        {
            _reportRepository = reportRepository;
            _reportFactory = reportFactory;
            _sessionRepository = sessionRepository;
            _recomendationsService = recomendationsService;
        }

        public IEnumerable<ReportInfo> GetMissingReports(Guid sessionId)
        {
            var session = _sessionRepository.Get(sessionId);
            var existsReports = GetReports(sessionId);
            var result = _recomendationsService.GetRecomendatedReports(session).ToList();
            result.RemoveAll(e => existsReports.ContainsReportInfo(e));
            return result;
        }

        public IEnumerable<ReportInfo> GetReports(Guid sessionId)
        {
            return _reportRepository.GetList(sessionId).Select(e => e.GetReportInfo());
        }

        public void Save(Guid sessionId, string fileName, string fileContent)
        {
            var xmlContent = XDocument.Parse(fileContent);
            var report = _reportFactory.GetReport(xmlContent);
            _reportRepository.Save(sessionId, fileName, report);
        }

        public void SaveWrongReport(Guid sessionId, string fileName, string fileContent, string errorMessage)
        {
            _reportRepository.SaveWrongReport(sessionId, fileName, errorMessage, fileContent);
        }
    }
}