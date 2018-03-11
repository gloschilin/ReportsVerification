using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    [ValidatorQuarter(2)]
    public class CalculationContributionsVsSzvm24Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm24Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm24Validator;

        protected override int CalculationContributionsQuarter => 2;
        protected override int SzvmMonth => 4;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол1Посл3М.ToInt();
        }
    }
}