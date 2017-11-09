using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl6;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Ndfl6.Common
{
    public abstract class CommonNdflValidator : CommonConcreteReportValidator
    {
        protected abstract int Quarter { get; }

        protected CommonNdflValidator(IValidationContext context) 
            : base(context)
        {
        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var reportByQuarter = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                if (info == null)
                {
                    return false;
                }

                return info.Type == ReportTypes.Ndfl6 && info.ReportPeriod.Quarter == Quarter;
            });

            return reportByQuarter == null || IsValid((Файл)reportByQuarter.XsdReport, reports, sessionInfo);
        }

        protected abstract bool IsValid(Файл report, 
            IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }
}