using System;
using System.Xml.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.SzvM;

namespace ReportsVerification.Web.Builders
{
    public class SzvMInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.SzvM;
        protected string GetCompanyName(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected DateOfMonth GetReportMonth(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override ReportInfo GetReportInfoInternal(Файл xsdReport)
        {
            throw new NotImplementedException();
        }

        protected override bool Allow(Файл xmlReport)
        {
            throw new NotImplementedException();
        }
    }
}