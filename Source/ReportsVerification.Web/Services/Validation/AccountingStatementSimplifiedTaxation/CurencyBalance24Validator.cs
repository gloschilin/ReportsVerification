using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance24Validator
        : Common2Validator
    {
        public CurencyBalance24Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }
}