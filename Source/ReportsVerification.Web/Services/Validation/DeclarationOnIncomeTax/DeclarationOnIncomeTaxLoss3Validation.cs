using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class DeclarationOnIncomeTaxLoss3Validation : DeclarationOnIncomeTaxCommonLossCommonValidation
    {
        public DeclarationOnIncomeTaxLoss3Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxCommonLoss3Validation;
        protected override int Quarter => 3;
    }
}