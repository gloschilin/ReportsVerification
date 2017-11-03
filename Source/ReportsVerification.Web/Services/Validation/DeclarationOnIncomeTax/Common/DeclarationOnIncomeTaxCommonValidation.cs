using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common
{
    public abstract class DeclarationOnIncomeTaxCommonValidation : CommonConcreteValidationService
    {
        protected abstract int Quarter { get; }

        protected DeclarationOnIncomeTaxCommonValidation(IValidationHandler handler) : base(handler)
        {
        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var wrongReports = reports
                .Where(e => e.ReportType == ReportTypes.DeclarationOnIncomeTax)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>) e.GetReportInfo()).ReportPeriod.Quarter == Quarter)
                .Where(e=> IsInvalid(e, reports, sessionInfo));

            return !wrongReports.Any();
        }

        protected abstract bool IsInvalid(Report report, 
            IReadOnlyCollection<Report>  allReports, SessionInfo sessionInfo);
    }
}