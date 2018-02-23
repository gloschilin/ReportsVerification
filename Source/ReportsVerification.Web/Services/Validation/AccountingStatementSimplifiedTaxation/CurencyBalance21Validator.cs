using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance21Validator
        : Common2Validator
    {
        public CurencyBalance21Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }
}