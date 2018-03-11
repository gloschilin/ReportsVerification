using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    [ValidatorQuarter(2)]
    public class CalculationContributionsVsSzvm26Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm26Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm26Validator;

        protected override int CalculationContributionsQuarter => 2;
        protected override int SzvmMonth => 6;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол3Посл3М.ToInt();
        }
    }
}