using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Builders
{
    public abstract class CommonConcreteInfoBuilder: IConcreteReportInfoBuilder
    {
        protected abstract ReportTypes ReportType { get; }

        public bool TryGetInfo(XDocument xmlFileContent, out ReportInfo reportInfo)
        {
            reportInfo = null;
            if (!Allow(xmlFileContent))
            {
                return false;
            }

            reportInfo = new ReportInfo(ReportType, GetReportMonth(xmlFileContent), GetCompanyName(xmlFileContent));
            return true;
        }

        protected abstract string GetCompanyName(XDocument xmlFileContent);

        protected abstract DateOfMonth GetReportMonth(XDocument xmlFileContent);

        protected abstract bool Allow(XDocument xmlFileContent);
    }
}