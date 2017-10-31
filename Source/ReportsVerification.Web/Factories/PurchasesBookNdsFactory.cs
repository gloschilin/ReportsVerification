using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
{
    public class PurchasesBookNdsFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new PurchasesBookNds(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.PurchasesBookNds;
    }
}