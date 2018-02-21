using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class RevenuesNds4Validator : CommonRevenuesNdsValidator
    {
        public RevenuesNds4Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.DeclarationOnIncomeTaxRevenuesNds4Validator;
        protected override int Quarter => 4;
    }
}