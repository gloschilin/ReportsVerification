using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class DeclarationOnIncomeTaxRevenuesNds2Validation : DeclarationOnIncomeTaxRevenuesNdsCommonValidation
    {
        public DeclarationOnIncomeTaxRevenuesNds2Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.DeclarationOnIncomeTaxRevenuesNds1Validation;
        protected override int Quarter => 2;
    }
}