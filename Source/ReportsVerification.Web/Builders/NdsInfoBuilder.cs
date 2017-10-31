using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.Nds;

namespace ReportsVerification.Web.Builders
{
    public class NdsInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.Nds;
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