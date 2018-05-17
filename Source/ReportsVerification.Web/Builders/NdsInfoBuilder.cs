using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Nds;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class NdsInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Nds;

        protected string GetCompanyName(Файл xmlFileContent, out string inn)
        {
            if (!Allow(xmlFileContent))
            {
                throw new ApplicationException("Неверный билдер для отчета");
            }

            var item = xmlFileContent.Документ.СвНП.Item;
            var ul = item as ФайлДокументСвНПНПЮЛ;
            if (ul != null)
            {
                return GetCompanyName(ul, out inn);
            }
            var fl = item as ФайлДокументСвНПНПФЛ;
            if (fl != null)
            {
                return GetCompanyName(fl, out inn);
            }

            throw new ApplicationException(
                "Невозможно определить наименование организации. Неизвестный тип значения узла XML");
        }

        private static string GetCompanyName(ФайлДокументСвНПНПФЛ fl, out string inn)
        {
            inn = fl.ИННФЛ;
            return $"{fl.ФИО.Фамилия} {fl.ФИО.Имя} {fl.ФИО.Отчество}";
        }

        private static string GetCompanyName(ФайлДокументСвНПНПЮЛ ul, out string inn)
        {
            inn = ul.ИННЮЛ;
            return $"{ul.НаимОрг}";
        }


        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            var period = new DateOfQuarter().ReadFromPeriod(
                    int.Parse(xsdReport.Документ.ОтчетГод),
                    int.Parse(xsdReport.Документ.Период)
                );

            string inn;
            var companyName = GetCompanyName(xsdReport, out inn);

            var info = ReportInfoFactory.CreateReportInfoRevision(ReportType, period, companyName, inn,
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));
            info.Version = xsdReport.ВерсПрог;
            return info;
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1151001";
        }

        public NdsInfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}