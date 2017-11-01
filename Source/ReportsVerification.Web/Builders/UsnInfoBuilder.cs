using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Usn;

namespace ReportsVerification.Web.Builders
{
    public class UsnInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Usn;
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
            return xmlReport != null && xmlReport.Документ?.КНД == "1152017";
        }
    }
}