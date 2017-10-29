using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.DeclarationOnPropertyTax;

namespace ReportsVerification.Web.Builders
{
    public class DeclarationOnPropertyTaxInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.DeclarationOnPropertyTax;
        protected override string GetCompanyName(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override DateOfMonth GetReportMonth(Файл xmlFileContent)
        {
            throw new NotImplementedException();
        }

        protected override bool Allow(Файл xmlReport)
        {
            throw new NotImplementedException();
        }
    }
}