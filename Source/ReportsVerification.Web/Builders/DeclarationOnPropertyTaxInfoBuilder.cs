using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.DeclarationOnPropertyTax;

namespace ReportsVerification.Web.Builders
{
    public class DeclarationOnPropertyTaxInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.DeclarationOnPropertyTax;
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


        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var period = new DateOfQuarter().ReadFromPeriod(
                    int.Parse(xsdReport.Документ.ОтчетГод),
                    int.Parse(xsdReport.Документ.Период)
                );

            return new ReportInfoRevistion<DateOfQuarter>(ReportType,
                period, 
                GetCompanyName(xsdReport),
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport != null && xmlReport.Документ?.КНД == "1152026";
        }
    }
}