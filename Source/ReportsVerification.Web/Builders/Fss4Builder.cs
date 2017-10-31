using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.Xsd.Fss4;

namespace ReportsVerification.Web.Builders
{
    public class Fss4Builder : CommonConcreteInfoBuilder<F4ReportType>
    {
        protected override ReportTypes ReportType => ReportTypes.Fss4;

        protected override ReportInfo GetReportInfoInternal(F4ReportType xsdReport)
        {
            var date = DateOfMonth.ReadFssDate(xsdReport.TITLE);
            return new ReportInfo(ReportType, date, xsdReport.TITLE.NAME);
        }

        protected override bool Allow(F4ReportType xmlReport)
        {
            return true;
        }
    }
}