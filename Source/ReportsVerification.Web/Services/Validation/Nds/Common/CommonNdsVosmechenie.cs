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
    public abstract class CommonNdsVosmechenie : CommonConcreteValidationService
    {
        protected abstract int NdsQuarter { get; }

        protected CommonNdsVosmechenie(IValidationHandler handler) : base(handler)
        {

        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var incorrectReports = reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == NdsQuarter)
                .Select(e => e.XsdReport).OfType<Файл>()
                .Where(e=> e.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() > 0)
                .ToArray();

            return !incorrectReports.Any();
        }
    }
}