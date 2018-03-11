using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.FirstErrors
{
    [ValidatorQuarter(4)]
    public class First41ErrorsValidator
        : CommonFirstErrorsValidator
    {
        public First41ErrorsValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsFirst41ErrorsValidator;

        protected override int Quarter => 4;
        protected override int Month => 10;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум1Посл3М;
        }
    }
}