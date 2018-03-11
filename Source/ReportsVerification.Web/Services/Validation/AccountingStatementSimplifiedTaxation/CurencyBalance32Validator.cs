using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    [ValidatorQuarter(2)]
    public class CurencyBalance32Validator
        : Common3Validator
    {
        public CurencyBalance32Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }
}