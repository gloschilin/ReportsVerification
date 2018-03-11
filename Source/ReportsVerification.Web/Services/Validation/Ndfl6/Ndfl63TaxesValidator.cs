using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    [ValidatorQuarter(3)]
    public class Ndfl63TaxesValidator : Ndfl6TaxesValidator
    {
        public Ndfl63TaxesValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl63TaxesValidator;
        protected override int Quarter => 3;
    }
}