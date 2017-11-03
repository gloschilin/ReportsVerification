using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    public class DeclarationOnIncomeTaxLoss2Validation : DeclarationOnIncomeTaxCommonLossCommonValidation
    {
        public DeclarationOnIncomeTaxLoss2Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxCommonLoss2Validation;
        protected override int Quarter => 2;
    }
}