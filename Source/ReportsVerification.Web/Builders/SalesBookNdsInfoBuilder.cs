using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.SalesBookNds;

namespace ReportsVerification.Web.Builders
{
    public class SalesBookNdsInfoBuilder: CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.SalesBookNds;

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            return new ReportInfoRevistion(ReportType,  
                new DateOfMonth(DateTime.Now.Year, DateTime.Now.Month), 
                "",
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.Индекс == "0000090";
        }
    }
}