using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.FirstErrors
{
    [ValidatorQuarter(1)]
    public class First12ErrorsValidator
        : CommonFirstErrorsValidator
    {
        public First12ErrorsValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsFirst12ErrorsValidator;

        protected override int Quarter => 1;
        protected override int Month => 2;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум2Посл3М;
        }
    }
}