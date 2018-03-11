using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 1 квартал
    /// </summary>
    [ValidatorQuarter(1)]
    public class DirectCosts1Validator : CommonDirectCostsValidator
    {
        public DirectCosts1Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxDirectCosts1Validator;
        protected override int Quarter => 1;
    }
}