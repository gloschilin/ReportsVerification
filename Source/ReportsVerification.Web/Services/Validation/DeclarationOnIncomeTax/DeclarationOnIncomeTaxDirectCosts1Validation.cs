using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 1 квартал
    /// </summary>
    public class DeclarationOnIncomeTaxDirectCosts1Validation
        : DeclarationOnIncomeTaxCommonDirectCostsValidation
    {
        public DeclarationOnIncomeTaxDirectCosts1Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxCommonDirectCosts1;
        protected override int Quarter => 1;
    }
}