using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.CalculationContributions.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.FirstErrors
{
    [ValidatorQuarter(4)]
    public class First42ErrorsValidator
        : CommonFirstErrorsValidator
    {
        public First42ErrorsValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsFirst42ErrorsValidator;

        protected override int Quarter => 4;
        protected override int Month => 11;
        protected override decimal GetSum(СвСум1Тип value)
        {
            return value.Сум2Посл3М;
        }
    }
}