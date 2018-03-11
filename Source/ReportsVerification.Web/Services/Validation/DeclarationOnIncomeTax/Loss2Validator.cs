using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    [ValidatorQuarter(2)]
    public class Loss2Validator : CommonLossValidator
    {
        public Loss2Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxLoss2Validator;
        protected override int Quarter => 2;
    }
}