using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 3 квартал
    /// </summary>
    public class DeclarationOnIncomeTaxDirectCosts3Validation
        : DeclarationOnIncomeTaxCommonDirectCostsValidation
    {
        public DeclarationOnIncomeTaxDirectCosts3Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxCommonDirectCosts3;
        protected override int Quarter => 3;
    }
}