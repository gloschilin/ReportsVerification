using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    public class TransportDeclarationFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new TransportDeclaration(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.TransportDeclaration;
    }
}