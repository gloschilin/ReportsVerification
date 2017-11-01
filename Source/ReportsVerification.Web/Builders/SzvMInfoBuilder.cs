using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
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
                    int.Parse(xsdReport.СЗВМ.ОтчетныйПериод.КалендарныйГод),
                    int.Parse(xsdReport.СЗВМ.ОтчетныйПериод.Месяц)
                );

            SzvMReportInfoType type;

            switch (xsdReport.СЗВМ.ТипФормы)
            {
                case "1":
                    type = SzvMReportInfoType.Initial;
                    break;
                case "2":
                    type = SzvMReportInfoType.Complementary;
                    break;
                case "3":
                    type = SzvMReportInfoType.Canceling;
                    break;
                default: 
                    throw new ApplicationException("Необработанный тип формы СЗВ-М");
            }

            return new SzvMReportInfo(ReportType, month, name, type);
        }

        protected override bool Allow(ЭДПФР xmlReport)
        {
            return true;
        }
    }
}