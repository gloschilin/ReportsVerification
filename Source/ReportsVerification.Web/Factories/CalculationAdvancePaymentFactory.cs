using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
{
    public class CalculationAdvancePaymentFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new CalculationAdvancePayment(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.CalculationAdvancePayment;
    }
}