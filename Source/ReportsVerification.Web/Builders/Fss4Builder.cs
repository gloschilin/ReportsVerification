using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Fss4;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class Fss4Builder : CommonConcreteInfoBuilder<F4ReportType>
    {
        protected override ReportTypes ReportType => ReportTypes.Fss4;

        protected override ReportInfo GetReportInfoInternal(F4ReportType xsdReport)
        {
            var date = new DateOfQuarter().ReadFssDate(xsdReport.TITLE);

            var info = ReportInfoFactory.CreateReportInfoRevision(ReportType, date,
                xsdReport.TITLE.NAME, xsdReport.TITLE.INN,
                int.Parse(xsdReport.TITLE.NumCorr ?? "0"));

            return info;
        }

        protected override bool Allow(F4ReportType xmlReport)
        {
            return true;
        }

        public Fss4Builder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}