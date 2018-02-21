using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    public class CalculationContributionsVsSzvm410Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm410Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm410Validator;

        protected override int CalculationContributionsQuarter => 4;
        protected override int SzvmMonth => 10;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол1Посл3М.ToInt();
        }
    }
}