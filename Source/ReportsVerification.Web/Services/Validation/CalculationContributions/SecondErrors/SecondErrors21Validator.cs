using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.SecondErrors
{
    public class SecondErrors21Validator
        : CommonSecondErrorsValidator
    {
        public SecondErrors21Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsSecondErrors21Validator;
        protected override int Quarter => 2;
        protected override int Month => 4;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум1Посл3М;
        }
    }
}