﻿using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm
{
    public class CalculationContributionsVsSzvm39Validator
        : CommonCalculationContributionsVsSzvmValidator
    {
        public CalculationContributionsVsSzvm39Validator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type
            => ValidationStepType.CalculationContributionsVsSzvm39Validator;

        protected override int CalculationContributionsQuarter => 3;
        protected override int SzvmMonth => 9;
        protected override int GetCount(КолЛицТип value)
        {
            return value.Кол3Посл3М.ToInt();
        }
    }
}