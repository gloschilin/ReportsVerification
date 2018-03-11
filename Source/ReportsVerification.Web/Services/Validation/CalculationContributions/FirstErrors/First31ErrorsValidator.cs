using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.FirstErrors
{
    [ValidatorQuarter(3)]
    public class First31ErrorsValidator
        : CommonFirstErrorsValidator
    {
        public First31ErrorsValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsFirst31ErrorsValidator;

        protected override int Quarter => 3;
        protected override int Month => 7;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум1Посл3М;
        }
    }
}