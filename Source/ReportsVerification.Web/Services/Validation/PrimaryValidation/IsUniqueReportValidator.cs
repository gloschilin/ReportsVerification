﻿using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.PrimaryValidation
{
    [ValidatorQuarter(1)]
    public class IsUniqueReportValidator: CommonConcretePrimaryReportValidator
    {
        public override ReportTypes[] ReportTypesSupport => new ReportTypes[0];
        public IsUniqueReportValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.PrimaryReportsIsUniqueValidator;

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            return reports.Select(e => e.GetReportInfo().GetUniq()).GroupBy(e => e).All(e => e.Count() == 1);
        }
    }
}