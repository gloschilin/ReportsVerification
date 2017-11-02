using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    public class CalculationContributionsFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new CalculationContributions(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.CalculationContributions;
    }
}