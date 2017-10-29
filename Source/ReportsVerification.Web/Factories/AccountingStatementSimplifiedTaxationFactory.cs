using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
{
    public class AccountingStatementSimplifiedTaxationFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new AccountingStatementSimplifiedTaxation(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.AccountingStatementSimplifiedTaxation;
    }
}