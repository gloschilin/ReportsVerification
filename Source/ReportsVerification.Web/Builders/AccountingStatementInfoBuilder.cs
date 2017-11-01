using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;

namespace ReportsVerification.Web.Builders
{
    public class AccountingStatementInfoBuilder: CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.AccountingStatement;

        protected string GetCompanyName(Файл xmlFileContent)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            var item = xmlFileContent.Документ.СвНП.НПЮЛ;
            return GetCompanyName(item);
        }

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
            return new ReportInfoRevistion(ReportType, 
                GetReportMonth(xsdReport), 
                GetCompanyName(xsdReport),
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport != null && xmlReport.Документ?.КНД == "0710099";
        }
    }
}