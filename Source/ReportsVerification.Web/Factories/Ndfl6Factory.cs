using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories
{
    public class Ndfl6Factory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new Ndfl6(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.Ndfl6;
    }
}