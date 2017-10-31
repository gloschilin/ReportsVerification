using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.SalesBookNds;

namespace ReportsVerification.Web.Builders
{
    public class SalesBookNdsInfoBuilder: CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.SalesBookNds;

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            return new ReportInfo(ReportType, new DateOfMonth(DateTime.Now.Year, DateTime.Now.Month), "");
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.Индекс == "0000090";
        }
    }
}