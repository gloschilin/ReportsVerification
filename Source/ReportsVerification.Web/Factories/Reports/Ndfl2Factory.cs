using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    public class Ndfl2Factory : IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new Ndfl2(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.Ndfl2;
    }
}