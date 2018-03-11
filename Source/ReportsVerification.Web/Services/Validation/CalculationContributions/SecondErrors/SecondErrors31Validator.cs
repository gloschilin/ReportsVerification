using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.SecondErrors
{
    [ValidatorQuarter(3)]
    public class SecondErrors31Validator
        : CommonSecondErrorsValidator
    {
        public SecondErrors31Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsSecondErrors31Validator;
        protected override int Quarter => 3;
        protected override int Month => 7;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум1Посл3М;
        }
    }
}