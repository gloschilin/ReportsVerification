using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.PurchasesBookNds;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class PurchasesBookNdsInfoBuilder: CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.PurchasesBookNds;

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var info = ReportInfoFactory.CreateReportInfoRevision(ReportType, new DateOfQuarter(DateTime.Now),
                "", "", int.Parse(xsdReport.Документ.НомКорр ?? "0"));
            info.Version = xsdReport.ВерсПрог;
            return info;
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.Индекс == "0000080";
        }

        public PurchasesBookNdsInfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}