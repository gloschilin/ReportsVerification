﻿using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.Common
{
    public abstract class CommonValidator : CommonConcreteReportValidator
    {
        protected abstract int Quarter { get; }

        public override ReportTypes[] ReportTypesSupport => new[] { ReportTypes.CalculationContributions };

        protected CommonValidator(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var report = reports.FirstOrDefault(e =>
            {
                var reportInfo = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                return reportInfo != null && reportInfo.ReportPeriod.Quarter == Quarter &&
                       reportInfo.Type == ReportTypes.CalculationContributions;
            });

            if (report == null)
            {
                return true;
            }

            var xsdReport = report.XsdReport as Файл;

            return IsValid(xsdReport, reports, sessionInfo);
        }

        protected abstract bool IsValid(Файл xsdReport, 
            IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }
}