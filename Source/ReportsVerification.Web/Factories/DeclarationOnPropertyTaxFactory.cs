using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
{
    public class DeclarationOnPropertyTaxFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new DeclarationOnPropertyTax(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.DeclarationOnPropertyTax;
    }
}