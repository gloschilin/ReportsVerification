using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ConcreteReprots;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Factories.Reports
{
    public class Fss4Factory: IConcreteReportFactory
    {
        public Report GetReport(XDocument xmlContent)
        {
            return new Fss4(xmlContent);
        }

        public ReportTypes ReportType => ReportTypes.Fss4;
    }
}