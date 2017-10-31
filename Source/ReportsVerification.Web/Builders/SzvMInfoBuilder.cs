using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.Xsd.Szvm;

namespace ReportsVerification.Web.Builders
{
    public class SzvMInfoBuilder : CommonConcreteInfoBuilder<ЭДПФР>
    {
        protected override ReportTypes ReportType => ReportTypes.SzvM;
        protected override ReportInfo GetReportInfoInternal(ЭДПФР xsdReport)
        {
            var name = xsdReport.СЗВМ.Страхователь.НаименованиеКраткое;
            var month = new DateOfMonth(
                    int.Parse(xsdReport.СЗВМ.ОтчетныйПериод.Месяц),
                    int.Parse(xsdReport.СЗВМ.ОтчетныйПериод.КалендарныйГод)
                );
            return new ReportInfo(ReportType, month, name);
        }

        protected override bool Allow(ЭДПФР xmlReport)
        {
            return true;
        }
    }
}