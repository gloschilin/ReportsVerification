using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Repositories.Interfaces;
using Report = ReportsVerification.Web.DataObjects.Report;

namespace ReportsVerification.Web.Repositories
{
    public class ReportsRepository: IReportRepository
    {
        private readonly IMapper<Report, EF.Report> _toEntityMapper;
        private readonly IReportFactory _reportFactory;

        public ReportsRepository( 
            IMapper<Report, EF.Report> toEntityMapper,
            IReportFactory reportFactory)
        {
            _toEntityMapper = toEntityMapper;
            _reportFactory = reportFactory;
        }
        
        public void Save(Guid sessionId, string fileName, Report report)
        {
            var info = report.GetReportInfo();
            using (var context = new ReportsVertification())
            {
                var uniq = info.GetUniq();
                var entity = context.Reports
                    .Where(e => e.SessionId == sessionId)
                    .FirstOrDefault(e => e.Uniq == uniq);

                if (entity == null)
                {
                    entity = new EF.Report
                    {
                        Id = Guid.NewGuid(),
                        SessionId = sessionId,
                        FileName = fileName,
                        Uniq = uniq
                    };
                    context.Reports.Add(entity);
                }

                _toEntityMapper.Map(report, entity);
                context.SaveChanges();
            }
        }

        public void SaveWrongReport(Guid sessionId, string fileName, string wrongMessage, string content)
        {
            using (var context = new ReportsVertification())
            {
                var entity = new WrongReport
                {
                    Content = content,
                    DateCreate = DateTime.Now,
                    FileName = fileName,
                    Id = Guid.NewGuid(),
                    Message = wrongMessage,
                    SessionId = sessionId
                };

                context.WrongReports.Add(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<Report> GetList(Guid sessionId)
        {
            using (var context = new ReportsVertification())
            {
                var reports = context.Reports.Where(e => e.SessionId == sessionId)
                    .ToArray()
                    .Select(e =>
                    {
                        var xml = XDocument.Parse(e.Content);
                        var report = _reportFactory.GetReport(xml);
                        return report;
                    }).ToArray();
                return reports;
            }
        }
    }
}