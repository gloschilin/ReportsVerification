using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    public class CalculationContributionsVsSzvm412Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm412Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm412Validator;

        protected override int CalculationContributionsQuarter => 4;
        protected override int SzvmMonth => 12;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол3Посл3М.ToInt();
        }
    }
}