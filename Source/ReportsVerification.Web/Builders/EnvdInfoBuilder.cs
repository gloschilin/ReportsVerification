using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Envd;

namespace ReportsVerification.Web.Builders
{
    public class EnvdInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Envd;

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
            return xmlReport != null && xmlReport.Документ?.КНД == "1152016";
        }
    }
}