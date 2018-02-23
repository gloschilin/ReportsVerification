using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance31Validator
        : Common3Validator
    {
        public CurencyBalance31Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }
}