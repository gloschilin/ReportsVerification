using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
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

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            if (!Allow(xsdReport))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            var period = new DateOfQuarter().ReadFromPeriod(
                    int.Parse(xsdReport.Документ.ОтчетГод),
                    int.Parse(xsdReport.Документ.Период)
                );

            return new ReportInfoRevistion<DateOfQuarter>(ReportType,
                period, 
                GetCompanyName(xsdReport.Документ.СвНП.НПЮЛ),
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1152004";
        }
    }
}