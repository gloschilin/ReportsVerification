using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.WithNdfl6Base
{
    public class WithNdfl6Base4Validator
        : CommonWithNdfl6BaseValidator
    {
        public WithNdfl6Base4Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions4WithNdfl6BaseValidator;
        protected override int Quarter => 4;
    }
}