using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.FirstErrors
{
    public class First43ErrorsValidator
        : CommonFirstErrorsValidator
    {
        public First43ErrorsValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsFirst43ErrorsValidator;

        protected override int Quarter => 4;
        protected override int Month => 3;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум3Посл3М;
        }
    }
}