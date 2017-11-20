using System;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl2;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class Ndfl2InfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Ndfl2;

        protected string GetCompanyName(Файл xmlFileContent, out string inn)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            var item = xmlFileContent.Документ.First().СвНА.Item;
            var ul = item as ФайлДокументСвНАСвНАЮЛ;
            if (ul != null)
            {
                return GetCompanyName(ul, out inn);
            }
            var fl = item as ФайлДокументСвНАСвНАФЛ;
            if (fl != null)
            {
                return GetCompanyName(fl, out inn);
            }

            throw new ApplicationException(
                "Невозможно определить наименование организации. Неизвестный тип значения узла XML");
        }
        
        private static string GetCompanyName(ФайлДокументСвНАСвНАФЛ fl, out string inn)
        {
            inn = fl.ИННФЛ;
            return $"{fl.ФИО.Фамилия} {fl.ФИО.Имя} {fl.ФИО.Отчество}";
        }

        private static string GetCompanyName(ФайлДокументСвНАСвНАЮЛ ul, out string inn)
        {
            inn = ul.ИННЮЛ;
            return $"{ul.НаимОрг}";
        }


        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var document = xsdReport.Документ.First();

            var period = new DateOfQuarter(int.Parse(xsdReport.СвРекв.ОтчетГод), 4);

            string inn;
            var companyName = GetCompanyName(xsdReport, out inn);

            var info = ReportInfoFactory.Create2NdflReportInfo(period, companyName, inn,
                int.Parse(document.НомКорр ?? "0"), int.Parse(document.Признак));

            return info;
        }

        protected override bool Allow(Файл xmlReport)
        {
            var doc = xmlReport.Документ.First();
            return doc.КНД == "1151078";
        }

        public Ndfl2InfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}