using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax
{
    /// <summary>
    /// Соотношение прямых расходов и выручки от реализации 3 квартал
    /// </summary>
    public class DirectCosts3Validator : CommonDirectCostsValidator
    {
        public DirectCosts3Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.DirectCosts3Validator;
        protected override int Quarter => 3;
    }
}