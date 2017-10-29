using System;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Builders
{
    public class Ndfl2InfoBuilder : CommonConcreteInfoBuilder
    {
        protected override ReportTypes ReportType => ReportTypes.Ndfl2;

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