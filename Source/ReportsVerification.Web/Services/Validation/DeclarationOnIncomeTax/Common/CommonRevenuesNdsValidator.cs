using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.DeclarationOnIncomeTax;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax.Common
{
    public abstract class CommonRevenuesNdsValidator : CommonValidator
    {
        protected CommonRevenuesNdsValidator(IValidationContext context) : base(context)
        {
        }

        protected override bool IsInvalid(Report report, 
            IReadOnlyCollection<Report> allReports, SessionInfo sessionInfo)
        {
            var file = (Файл)report.XsdReport;
            var ndsForQuarterReports = Enumerable.Range(1, Quarter)
                .Select(quarter=> GetNdsSums(allReports, quarter)).Sum();

            var fileRevenues = file.Документ.Прибыль.Items.OfType<ФайлДокументПрибыльРасчНал>()
                .Select(e => e.ДохРеалВнеРеал.ДохРеал.ВырРеалИтог.ToDecimal()).First();

            return ndsForQuarterReports != fileRevenues;
        }

        private static decimal GetNdsSums(IEnumerable<Report> reports, int quarter)
        {
            var ndsByQuarter = (DataObjects.Xsd.Nds.Файл)reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .First(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == quarter)
                .XsdReport;

            var summ = ndsByQuarter.Документ.НДС.СумУпл164.СумНалОб.РеалТов18.НалБаза.ToDecimal()
                       + ndsByQuarter.Документ.НДС.СумУпл164.СумНалОб.РеалТов18.НалБаза.ToDecimal()
                       + ndsByQuarter.Документ.НДС.СумУпл164.СумНалОб.РеалТов10.НалБаза.ToDecimal()
                       + ndsByQuarter.Документ.НДС.СумУпл164.СумНалОб.РеалТов118.НалБаза.ToDecimal()
                       + ndsByQuarter.Документ.НДС.СумУпл164.СумНалОб.РеалТов110.НалБаза.ToDecimal()
                       + ndsByQuarter.Документ.НДС.СумУпл164.СумНалОб.РеалСрок1511_118.НалБаза.ToDecimal();

            return summ;
        }
    }
}