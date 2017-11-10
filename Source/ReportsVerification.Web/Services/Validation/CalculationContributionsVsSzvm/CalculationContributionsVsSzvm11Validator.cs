using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    public class CalculationContributionsVsSzvm11Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm11Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type 
            => ValidationStepType.CalculationContributionsVsSzvm11Validator;

        protected override int CalculationContributionsQuarter => 1;
        protected override int SzvmMonth => 1;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол1Посл3М.ToInt();
        }
    }
}