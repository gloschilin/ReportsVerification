using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance23Validator
        : Common2Validator
    {
        public CurencyBalance23Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }
}