using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.Nds;

namespace ReportsVerification.Web.Builders
{
    public class NdsInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Nds;

        protected string GetCompanyName(Файл xmlFileContent)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            var item = xmlFileContent.Документ.СвНП.Item;
            var ul = item as ФайлДокументСвНПНПЮЛ;
            if (ul != null)
            {
                return GetCompanyName(ul);
            }
            var fl = item as ФайлДокументСвНПНПФЛ;
            if (fl != null)
            {
                return GetCompanyName(fl);
            }

            throw new ApplicationException(
                "Невозможно определить наименование организации. Неизвестный тип значения узла XML");
        }

        private static string GetCompanyName(ФайлДокументСвНПНПФЛ fl)
        {
            return $"{fl.ФИО.Фамилия} {fl.ФИО.Имя} {fl.ФИО.Отчество}";
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

            return DateOfMonth.FromPeriod(int.Parse(xmlFileContent.Документ.ОтчетГод),
                xmlFileContent.Документ.Период);
        }

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            return new ReportInfo(ReportType, GetReportMonth(xsdReport), GetCompanyName(xsdReport));
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1151001";
        }
    }
}