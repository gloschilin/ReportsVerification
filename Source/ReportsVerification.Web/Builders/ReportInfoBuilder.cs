using System.Collections.Generic;
using System.Xml.Linq;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Builders
{
    public class ReportInfoBuilder: IReportInfoBuilder
    {
        private readonly IEnumerable<IConcreteReportInfoBuilder> _builders;
        public ReportInfoBuilder(IEnumerable<IConcreteReportInfoBuilder> builders)
        {
            _builders = builders;
        }

        public bool TryGetInfo(XDocument xmlFileContent, out ReportInfo reportInfo)
        {
            reportInfo = null;
            foreach (var builder in _builders)
            {
                if (builder.TryGetInfo(xmlFileContent, out reportInfo))
                {
                    return true;
                }
            }

            return false;
        }
    }
}