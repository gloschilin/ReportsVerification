using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.TransportDeclaration;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Builders
{
    public class TransportDeclarationInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.TransportDeclaration;

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

            var info = ReportInfoFactory.CreateReportInfoRevision(ReportType, period,
                xsdReport.Документ.СвНП.НПЮЛ.НаимОрг,
                xsdReport.Документ.СвНП.НПЮЛ.ИННЮЛ, 
                int.Parse(xsdReport.Документ.НомКорр ?? "0"));

            return info;
        }

        protected override bool Allow(Файл xmlReport)
        {
            return xmlReport.Документ.КНД == "1152004";
        }

        public TransportDeclarationInfoBuilder(IReportInfoFactory reportInfoFactory) : base(reportInfoFactory)
        {
        }
    }
}