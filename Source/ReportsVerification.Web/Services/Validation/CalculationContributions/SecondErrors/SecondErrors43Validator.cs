using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.SecondErrors
{
    public class SecondErrors43Validator
        : CommonSecondErrorsValidator
    {
        public SecondErrors43Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsSecondErrors43Validator;
        protected override int Quarter => 4;
        protected override int Month => 12;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум3Посл3М;
        }
    }

}