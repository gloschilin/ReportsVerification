using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
{
    public class AccountingStatementFactory: IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new AccountingStatement(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.AccountingStatement;
    }
}