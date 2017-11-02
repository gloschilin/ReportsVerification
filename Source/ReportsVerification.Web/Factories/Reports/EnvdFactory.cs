using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    public class EnvdFactory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new Envd(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.Envd;
    }
}