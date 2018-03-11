using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    [ValidatorQuarter(3)]
    public class CurencyBalance13Validator
        : Common1Validator
    {
        public CurencyBalance13Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }
}