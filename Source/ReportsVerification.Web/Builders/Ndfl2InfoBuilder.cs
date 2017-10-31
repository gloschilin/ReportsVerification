using System;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl2;

namespace ReportsVerification.Web.Builders
{
    public class Ndfl2InfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Ndfl2;

        protected string GetCompanyName(Файл xmlFileContent)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            var item = xmlFileContent.Документ.First().СвНА.Item;
            var ul = item as ФайлДокументСвНАСвНАЮЛ;
            if (ul != null)
            {
                return GetCompanyName(ul);
            }
            var fl = item as ФайлДокументСвНАСвНАФЛ;
            if (fl != null)
            {
                return GetCompanyName(fl);
            }

            throw new ApplicationException(
                "Невозможно определить наименование организации. Неизвестный тип значения узла XML");
        }
        
        private static string GetCompanyName(ФайлДокументСвНАСвНАФЛ fl)
        {
            return $"{fl.ФИО.Фамилия} {fl.ФИО.Имя} {fl.ФИО.Отчество}";
        }

        private static string GetCompanyName(ФайлДокументСвНАСвНАЮЛ ul)
        {
            return $"{ul.НаимОрг}";
        }

        protected DateOfMonth GetReportMonth(Файл xmlFileContent)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            return new DateOfMonth(int.Parse(xmlFileContent.Документ.First().ОтчетГод), 10);
        }

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var document = xsdReport.Документ.First();
            return new Ndfl2ReportInfo(ReportType, GetReportMonth(xsdReport), GetCompanyName(xsdReport),
                int.Parse(document.Признак));
        }

        protected override bool Allow(Файл xmlReport)
        {
            var doc = xmlReport.Документ.First();
            return doc.КНД == "1151078";
        }
    }
}