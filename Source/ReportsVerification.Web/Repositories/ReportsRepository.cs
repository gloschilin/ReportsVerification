using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Repositories.Interfaces;
using Report = ReportsVerification.Web.DataObjects.Report;

namespace ReportsVerification.Web.Repositories
{
    public class ReportsRepository: IReportRepository
    {
        private readonly IReportInfoBuilder _infoBuilder;
        private readonly IMapper<Report, EF.Report> _toEntityMapper;
        private readonly IReportFactory _reportFactory;

        public ReportsRepository(IReportInfoBuilder infoBuilder, 
            IMapper<Report, EF.Report> toEntityMapper,
            IReportFactory reportFactory)
        {
            _infoBuilder = infoBuilder;
            _toEntityMapper = toEntityMapper;
            _reportFactory = reportFactory;
        }

        public void Save(Guid sessionId, Report report)
        {
            var info = report.GetReportInfo();
            using (var context = new ReportsVertification())
            {
                var entity = context.Reports
                    .Where(e=>e.SessionId == sessionId)
                    .FirstOrDefault(e => e.Alias == info.Type.ToString() 
                                         && e.Month == info.ReportMonth.Month 
                                         && e.Year == info.ReportMonth.Year) ;
                if (entity == null)
                {
                    entity = new EF.Report
                    {
                        Id = Guid.NewGuid(),
                        SessionId = sessionId
                    };
                    context.Reports.Add(entity);
                }
                
                _toEntityMapper.Map(report, entity);
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