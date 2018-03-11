using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    [ValidatorQuarter(4)]
    public class CalculationContributionsVsSzvm411Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm411Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm411Validator;

        protected override int CalculationContributionsQuarter => 4;
        protected override int SzvmMonth => 11;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол2Посл3М.ToInt();
        }
    }
}