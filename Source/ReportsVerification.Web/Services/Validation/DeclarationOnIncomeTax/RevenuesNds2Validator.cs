using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    [ValidatorQuarter(2)]
    public class RevenuesNds2Validator : CommonRevenuesNdsValidator
    {
        public RevenuesNds2Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.DeclarationOnIncomeTaxRevenuesNds2Validator;
        protected override int Quarter => 2;
    }
}