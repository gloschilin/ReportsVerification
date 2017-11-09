using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions
{
    public class CalculationContributions2WithNdfl6BaseValidator
        : CommonCalculationContributionsWithNdfl6BaseValidator
    {
        public CalculationContributions2WithNdfl6BaseValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions2WithNdfl6BaseValidator;
        protected override int Quarter => 2;
    }
}