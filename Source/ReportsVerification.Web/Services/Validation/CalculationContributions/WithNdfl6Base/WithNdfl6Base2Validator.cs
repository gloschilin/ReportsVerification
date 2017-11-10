using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.WithNdfl6Base
{
    public class WithNdfl6Base2Validator
        : CommonWithNdfl6BaseValidator
    {
        public WithNdfl6Base2Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions2WithNdfl6BaseValidator;
        protected override int Quarter => 2;
    }
}