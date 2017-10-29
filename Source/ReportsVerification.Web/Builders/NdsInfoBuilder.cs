using System;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Builders
{
    public class NdsInfoBuilder : CommonConcreteInfoBuilder
    {
        protected override ReportTypes ReportType => ReportTypes.Nds;

        protected override string GetCompanyName(XDocument xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override DateOfMonth GetReportMonth(XDocument xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override bool Allow(XDocument xmlFileContent)
        {
            throw new NotImplementedException();
        }
    }
}