using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Szvm;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class SzvMInfoBuilder : CommonConcreteInfoBuilder<ЭДПФР>
    {
        protected override ReportTypes ReportType => ReportTypes.SzvM;
        protected override ReportInfo GetReportInfoInternal(ЭДПФР xsdReport)
        {
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

            var info = ReportInfoFactory.CreateSzvMReportInfo(type, month,
                xsdReport.СЗВМ.Страхователь.НаименованиеКраткое,
                xsdReport.СЗВМ.Страхователь.ИНН);
            return info;
        }

        protected override bool Allow(ЭДПФР xmlReport)
        {
            return true;
        }

        public SzvMInfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}