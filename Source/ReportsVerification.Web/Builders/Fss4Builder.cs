using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Fss4;

namespace ReportsVerification.Web.Builders
{
    public class Fss4Builder : CommonConcreteInfoBuilder<F4ReportType>
    {
        protected override ReportTypes ReportType => ReportTypes.Fss4;

        protected override ReportInfo GetReportInfoInternal(F4ReportType xsdReport)
        {
            var date = new DateOfQuarter().ReadFssDate(xsdReport.TITLE);
            return new ReportInfoRevistion<DateOfQuarter>(ReportType, 
                date, 
                xsdReport.TITLE.NAME,
                int.Parse(xsdReport.TITLE.NumCorr ?? "0"));
        }

        protected override bool Allow(F4ReportType xmlReport)
        {
            return true;
        }
    }
}