using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    [ValidatorQuarter(4)]
    public class Ndfl64TaxesValidator : Ndfl6TaxesValidator
    {
        public Ndfl64TaxesValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl64TaxesValidator;
        protected override int Quarter => 4;
    }
}