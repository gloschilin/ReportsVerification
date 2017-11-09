using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    public class Ndfl61TaxesValidator : Ndfl6TaxesValidator
    {
        public Ndfl61TaxesValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl61TaxesValidator;
        protected override int Quarter => 1;
    }
}