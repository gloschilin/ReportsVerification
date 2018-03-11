using ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation
{
    [ValidatorQuarter(4)]
    public class CurencyBalance34Validator
        : Common3Validator
    {
        public CurencyBalance34Validator(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }
}