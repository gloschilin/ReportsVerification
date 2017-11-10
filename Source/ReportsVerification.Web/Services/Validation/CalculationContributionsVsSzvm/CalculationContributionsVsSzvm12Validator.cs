using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    public class CalculationContributionsVsSzvm12Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm12Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm12Validator;

        protected override int CalculationContributionsQuarter => 1;
        protected override int SzvmMonth => 2;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол2Посл3М.ToInt();
        }
    }
}