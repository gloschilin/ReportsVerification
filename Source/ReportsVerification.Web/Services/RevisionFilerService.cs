using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services
{
    public class RevisionFilerService : IRevisionFilerService
    {
        public IEnumerable<Report> GetActualReports(IReadOnlyCollection<Report> allReports)
        {
            return from currentReport in allReports
                let resultReport = GetReportByMaxRevision(currentReport, allReports)
                select currentReport;
        }

        private static Report GetReportByMaxRevision(Report currentReport, IEnumerable<Report> allReports)
        {
            var info = currentReport.GetReportInfo();

            var monthRevisionInfo = info as ReportInfoRevistion<DateOfMonth>;

            if (monthRevisionInfo != null)
            {
                return GetReportByMaxRevision(monthRevisionInfo, allReports);
            }

            var quarterRevisionInfo = info as ReportInfoRevistion<DateOfQuarter>;
            return quarterRevisionInfo != null 
                ? GetReportByMaxRevision(quarterRevisionInfo, allReports) 
                : currentReport;
        }

        private static Report GetReportByMaxRevision(ReportInfoRevistion<DateOfMonth> info,
            IEnumerable<Report> allReports)
        {
            var result = allReports.Where(e =>
            {
                var infoByReport = e.GetReportInfo() as ReportInfoRevistion<DateOfMonth>;
                if (infoByReport == null)
                {
                    return false;
                }

                return infoByReport.ReportPeriod == info.ReportPeriod
                       && infoByReport.Type == info.Type;
            }).OrderByDescending(e =>
            {
                var infoByReport = e.GetReportInfo() as ReportInfoRevistion<DateOfMonth>;
                if (infoByReport == null)
                {
                    return -1;
                }
                return infoByReport.RevisionNumber;
            }).First();

            return result;
        }

        private static Report GetReportByMaxRevision(ReportInfoRevistion<DateOfQuarter> info,
            IEnumerable<Report> allReports)
        {
            var result = allReports.Where(e =>
            {
                var infoByReport = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                if (infoByReport == null)
                {
                    return false;
                }

                return infoByReport.ReportPeriod == info.ReportPeriod
                       && infoByReport.Type == info.Type;
            }).OrderByDescending(e =>
            {
                var infoByReport = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                if (infoByReport == null)
                {
                    return -1;
                }
                return infoByReport.RevisionNumber;
            }).First();

            return result;
        }
    }
}