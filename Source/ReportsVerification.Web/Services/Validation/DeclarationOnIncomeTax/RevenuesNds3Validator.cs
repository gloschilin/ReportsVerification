using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class RevenuesNds3Validator : CommonRevenuesNdsValidator
    {
        public RevenuesNds3Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.RevenuesNds3Validator;
        protected override int Quarter => 2;
    }
}