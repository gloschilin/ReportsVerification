using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.WithNdfl6Base
{
    [ValidatorQuarter(1)]
    public class WithNdfl6Base1Validator
        : CommonWithNdfl6BaseValidator
    {
        public WithNdfl6Base1Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions1WithNdfl6BaseValidator;
        protected override int Quarter => 1;
    }
}