using System;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.CalculationAdvancePayment;

namespace ReportsVerification.Web.Builders
{
    public class CalculationAdvancePaymentInfoBuilder : CommonConcreteInfoBuilder<Файл>
    {
        protected override ReportTypes ReportType => ReportTypes.CalculationAdvancePayment;

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