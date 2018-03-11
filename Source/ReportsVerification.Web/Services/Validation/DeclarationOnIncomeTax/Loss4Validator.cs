using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    [ValidatorQuarter(4)]
    public class Loss4Validator : CommonLossValidator
    {
        public Loss4Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxLoss4Validator;
        protected override int Quarter => 4;
    }
}