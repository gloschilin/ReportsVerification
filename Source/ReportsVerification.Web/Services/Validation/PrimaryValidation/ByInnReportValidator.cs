﻿using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Specifications;

namespace ReportsVerification.Web.Services.Validation.PrimaryValidation
{
    [ValidatorQuarter(1)]
    public class ByInnReportValidator: CommonConcretePrimaryReportValidator
    {
        public override ReportTypes[] ReportTypesSupport => new ReportTypes[0];

        private readonly ReportHasInnSpecification _reportHasInnSpecification;

        public ByInnReportValidator(IValidationContext context, 
            ReportHasInnSpecification reportHasInnSpecification) : base(context)
        {
            _reportHasInnSpecification = reportHasInnSpecification;
        }

        protected override ValidationStepType Type => ValidationStepType.PrimaryReportsByInnValidator;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            return reports.Select(e => e.GetReportInfo())
                .Where(e => _reportHasInnSpecification.IsSpecificatedBy(e))
                .Select(e => e.Inn).GroupBy(e => e).Count() <= 1;
        }
    }
}