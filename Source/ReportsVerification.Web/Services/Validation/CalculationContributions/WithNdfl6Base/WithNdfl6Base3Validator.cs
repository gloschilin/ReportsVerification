using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.WithNdfl6Base
{
    [ValidatorQuarter(3)]
    public class WithNdfl6Base3Validator
        : CommonWithNdfl6BaseValidator
    {
        public WithNdfl6Base3Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions3WithNdfl6BaseValidator;
        protected override int Quarter => 3;
    }
}