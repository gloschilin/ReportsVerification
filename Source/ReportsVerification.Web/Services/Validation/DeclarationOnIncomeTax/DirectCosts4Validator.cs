using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 3 квартал
    /// </summary>
    [ValidatorQuarter(4)]
    public class DirectCosts4Validator : CommonDirectCostsValidator
    {
        public DirectCosts4Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DeclarationOnIncomeTaxDirectCosts4Validator;
        protected override int Quarter => 4;
    }
}