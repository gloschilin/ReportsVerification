using System;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Builders
{
    public class CalculationContributionsInfoBuilder : CommonConcreteInfoBuilder
    {
        protected override ReportTypes ReportType => ReportTypes.CalculationContributions;

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