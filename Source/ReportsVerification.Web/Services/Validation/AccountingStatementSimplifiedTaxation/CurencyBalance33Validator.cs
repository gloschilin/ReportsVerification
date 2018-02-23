using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance33Validator
        : Common3Validator
    {
        public CurencyBalance33Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }
}