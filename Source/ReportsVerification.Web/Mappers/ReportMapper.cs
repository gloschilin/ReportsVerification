using System;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Mappers.Interfaces;

namespace ReportsVerification.Web.Mappers
{
    public class ReportMapper: IMapper<Report, Repositories.EF.Report>
    {
        public void Map(Report source, Repositories.EF.Report destination)
        {
            var reportInfo = source.GetReportInfo();
            destination.Alias = source.ReportType.ToString();
            destination.Content = source.GetContent().ToString();
            destination.Month = reportInfo.ReportMonth.Month;
            destination.Year = reportInfo.ReportMonth.Year;
            destination.DateCreate = DateTime.Now;
        }
    }
}