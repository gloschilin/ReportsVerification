using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    public class DeclarationOnLandTaxFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new DeclarationOnLandTax(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.DeclarationOnLandTax;
    }
}