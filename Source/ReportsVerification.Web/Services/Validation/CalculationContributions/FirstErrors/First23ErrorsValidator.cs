using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.FirstErrors
{
    [ValidatorQuarter(2)]
    public class First23ErrorsValidator
        : CommonFirstErrorsValidator
    {
        public First23ErrorsValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsFirst23ErrorsValidator;

        protected override int Quarter => 2;
        protected override int Month => 6;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум3Посл3М;
        }
    }
}