using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.TransportDeclaration;

namespace ReportsVerification.Web.Builders
{
    public class TransportDeclarationInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.TransportDeclaration;

        private static string GetCompanyName(ФайлДокументСвНПНПЮЛ ul)
        {
            return $"{ul.НаимОрг}";
        }

        protected DateOfMonth GetReportMonth(Файл xmlFileContent)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            return DateOfMonth.ReadFromPeriod(int.Parse(xmlFileContent.Документ.ОтчетГод),
                int.Parse(xmlFileContent.Документ.Период));
        }

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            if (!Allow(xsdReport))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            return new ReportInfoRevistion(ReportType, 
                GetReportMonth(xsdReport), 
                GetCompanyName(xsdReport.Документ.СвНП.НПЮЛ),
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1152004";
        }
    }
}