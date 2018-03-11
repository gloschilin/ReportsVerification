using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.SecondErrors
{
    [ValidatorQuarter(3)]
    public class SecondErrors33Validator
        : CommonSecondErrorsValidator
    {
        public SecondErrors33Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsSecondErrors33Validator;
        protected override int Quarter => 3;
        protected override int Month => 9;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум3Посл3М;
        }
    }

}