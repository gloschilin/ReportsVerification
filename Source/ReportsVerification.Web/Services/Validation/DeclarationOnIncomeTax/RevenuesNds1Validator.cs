using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    [ValidatorQuarter(1)]
    public class RevenuesNds1Validator : CommonRevenuesNdsValidator
    {
        public RevenuesNds1Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.DeclarationOnIncomeTaxRevenuesNds1Validator;
        protected override int Quarter => 1;
    }
}