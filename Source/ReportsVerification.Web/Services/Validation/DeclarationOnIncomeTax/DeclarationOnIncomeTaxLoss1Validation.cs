using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class DeclarationOnIncomeTaxLoss1Validation : DeclarationOnIncomeTaxCommonLossCommonValidation
    {
        public DeclarationOnIncomeTaxLoss1Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxCommonLoss1Validation;
        protected override int Quarter => 1;
    }
}