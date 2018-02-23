using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    public class CurencyBalance14Validator
        : Common1Validator
    {
        public CurencyBalance14Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }
}