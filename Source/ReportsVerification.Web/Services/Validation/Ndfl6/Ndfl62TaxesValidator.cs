using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    [ValidatorQuarter(2)]
    public class Ndfl62TaxesValidator : Ndfl6TaxesValidator
    {
        public Ndfl62TaxesValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl62TaxesValidator;
        protected override int Quarter => 2;
    }
}