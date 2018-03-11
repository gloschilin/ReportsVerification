using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.SecondErrors
{
    [ValidatorQuarter(2)]
    public class SecondErrors23Validator
        : CommonSecondErrorsValidator
    {
        public SecondErrors23Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsSecondErrors23Validator;
        protected override int Quarter => 2;
        protected override int Month => 6;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум3Посл3М;
        }
    }
}