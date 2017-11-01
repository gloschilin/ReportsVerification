using System;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
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


        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var document = xsdReport.Документ.First();

            var period = new DateOfQuarter(int.Parse(document.ОтчетГод), 4);

            return new Ndfl2ReportInfo(ReportType, period, GetCompanyName(xsdReport),
                int.Parse(document.НомКорр ?? "0"),
                int.Parse(document.Признак));
        }

        protected override bool Allow(Файл xmlReport)
        {
            var doc = xmlReport.Документ.First();
            return doc.КНД == "1151078";
        }
    }
}