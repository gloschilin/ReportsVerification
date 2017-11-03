using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 2 квартал
    /// </summary>
    public class DeclarationOnIncomeTaxDirectCosts2Validation
        : DeclarationOnIncomeTaxCommonDirectCostsValidation
    {
        public DeclarationOnIncomeTaxDirectCosts2Validation(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxCommonDirectCosts2;
        protected override int Quarter => 2;
    }
}