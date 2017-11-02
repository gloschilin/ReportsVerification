using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.SalesBookNds;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class SalesBookNdsInfoBuilder: CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.SalesBookNds;

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var info = ReportInfoFactory.CreateReportInfoRevision(ReportType, new DateOfQuarter(DateTime.Now),
                "", "", int.Parse(xsdReport.Документ.НомКорр ?? "0"));

            return info;
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.Индекс == "0000090";
        }

        public SalesBookNdsInfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}