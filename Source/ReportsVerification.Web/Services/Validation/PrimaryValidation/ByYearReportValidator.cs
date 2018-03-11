﻿using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Specifications;

namespace ReportsVerification.Web.Services.Validation.PrimaryValidation
{
    [ValidatorQuarter(1)]
    public class ByYearReportValidator: CommonConcretePrimaryReportValidator
    {
        public override ReportTypes[] ReportTypesSupport => new ReportTypes[0];
        private readonly ReportHasDateSpecidication _reportHasDateSpecidication;

        public ByYearReportValidator(IValidationContext context,
            ReportHasDateSpecidication reportHasDateSpecidication) : base(context)
        {
            _reportHasDateSpecidication = reportHasDateSpecidication;
        }

        protected override ValidationStepType Type => ValidationStepType.PrimaryReportsByYearValidator;
        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            return reports.Select(e => e.GetReportInfo())
                .Where(e => _reportHasDateSpecidication.IsSpecificatedBy(e))
                .Select(e => e.GetStartReportPeriod()).Select(e => e?.Year).Distinct().Count() <= 1;
        }
    }
}