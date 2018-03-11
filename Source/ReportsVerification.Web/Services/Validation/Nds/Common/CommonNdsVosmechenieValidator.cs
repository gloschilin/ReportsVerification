using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Nds;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Nds.Common
{
    public abstract class CommonNdsVosmechenieValidator : CommonConcreteReportValidator
    {
        public override ReportTypes[] ReportTypesSupport => new[]
        {
            ReportTypes.Nds
        };

        protected abstract int Quarter { get; }

        protected CommonNdsVosmechenieValidator(IValidationContext context) : base(context)
        {

        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var ndsReportByQuarter = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                return info != null && info.ReportPeriod.Quarter == Quarter && info.Type == ReportTypes.Nds;
            });

            if (ndsReportByQuarter == null)
            {
                return true;
            }

            var xsd = (Файл)ndsReportByQuarter.XsdReport;
            return xsd.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() >= 0;
        }
    }
}