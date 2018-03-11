using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    [ValidatorQuarter(3)]
    public class CalculationContributionsVsSzvm38Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm38Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm38Validator;

        protected override int CalculationContributionsQuarter => 3;
        protected override int SzvmMonth => 8;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол2Посл3М.ToInt();
        }
    }
}