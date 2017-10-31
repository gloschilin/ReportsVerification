using System;
using ReportsVerification.Web.DataObjects;
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

            return DateOfMonth.FromPeriod(int.Parse(xmlFileContent.Документ.ОтчетГод),
                xmlFileContent.Документ.Период);
        }

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            if (!Allow(xsdReport))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            return new ReportInfo(ReportType, GetReportMonth(xsdReport), 
                GetCompanyName(xsdReport.Документ.СвНП.НПЮЛ));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1152004";
        }
    }
}