using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.SecondErrors
{
    [ValidatorQuarter(4)]
    public class SecondErrors41Validator
        : CommonSecondErrorsValidator
    {
        public SecondErrors41Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsSecondErrors41Validator;
        protected override int Quarter => 4;
        protected override int Month => 10;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум1Посл3М;
        }
    }
}