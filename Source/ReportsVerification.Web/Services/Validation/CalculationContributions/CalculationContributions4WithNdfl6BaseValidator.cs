using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions
{
    public class CalculationContributions4WithNdfl6BaseValidator
        : CommonCalculationContributionsWithNdfl6BaseValidator
    {
        public CalculationContributions4WithNdfl6BaseValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions4WithNdfl6BaseValidator;
        protected override int Quarter => 4;
    }
}