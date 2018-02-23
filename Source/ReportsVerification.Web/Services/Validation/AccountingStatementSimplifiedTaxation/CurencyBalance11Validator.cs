using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance11Validator
        :Common1Validator
    {
        public CurencyBalance11Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }
}