using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class RevenuesNds1Validator : CommonRevenuesNdsValidator
    {
        public RevenuesNds1Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.RevenuesNds1Validator;
        protected override int Quarter => 1;
    }
}