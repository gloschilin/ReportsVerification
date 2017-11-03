using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class DeclarationOnIncomeTaxRevenuesNds3Validation : DeclarationOnIncomeTaxRevenuesNdsCommonValidation
    {
        public DeclarationOnIncomeTaxRevenuesNds3Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.DeclarationOnIncomeTaxRevenuesNds3Validation;
        protected override int Quarter => 2;
    }
}