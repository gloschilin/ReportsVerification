using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    [ValidatorQuarter(1)]
    public class Loss1Validator : CommonLossValidator
    {
        public Loss1Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxLoss1Validator;
        protected override int Quarter => 1;
    }
}