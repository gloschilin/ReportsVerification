using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions
{
    public class CalculationContributions3WithNdfl6BaseValidator
        : CommonCalculationContributionsWithNdfl6BaseValidator
    {
        public CalculationContributions3WithNdfl6BaseValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributions3WithNdfl6BaseValidator;
        protected override int Quarter => 3;
    }
}