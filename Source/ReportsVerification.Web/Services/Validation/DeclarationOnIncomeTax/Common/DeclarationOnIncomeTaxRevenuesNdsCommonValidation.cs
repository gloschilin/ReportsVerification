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
    public abstract class DeclarationOnIncomeTaxRevenuesNdsCommonValidation
        : DeclarationOnIncomeTaxCommonValidation
    {
        protected DeclarationOnIncomeTaxRevenuesNdsCommonValidation(IValidationHandler handler) : base(handler)
        {
        }

        protected override bool IsInvalid(Report report, 
            IReadOnlyCollection<Report> allReports, SessionInfo sessionInfo)
        {
            var file = (Файл)report.XsdReport;
            var ndsForQuarterReports = GetNdsSums(allReports, Quarter);

            var fileRevenues = file.Документ.Прибыль.Items.OfType<ФайлДокументПрибыльРасчНал>()
                .Select(e => e.ДохРеалВнеРеал.ДохРеал.ВырРеалИтог.ToDecimal()).ToArray();

            return ndsForQuarterReports.Any(ndsForQuarterReport 
                => fileRevenues.Any(fileRevenue => fileRevenue != ndsForQuarterReport));
        }

        private static IEnumerable<decimal> GetNdsSums(IEnumerable<Report> reports, int quarter)
        {
            return reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == quarter)
                .Select(e => (DataObjects.Xsd.Nds.Файл)e.XsdReport)
                .Select(e => e.Документ.НДС.СумУпл164.СумНалОб.РеалТов18.НалБаза.ToDecimal()
                    + e.Документ.НДС.СумУпл164.СумНалОб.РеалТов18.НалБаза.ToDecimal()
                    + e.Документ.НДС.СумУпл164.СумНалОб.РеалТов10.НалБаза.ToDecimal()
                    + e.Документ.НДС.СумУпл164.СумНалОб.РеалТов118.НалБаза.ToDecimal()
                    + e.Документ.НДС.СумУпл164.СумНалОб.РеалТов110.НалБаза.ToDecimal()
                    + e.Документ.НДС.СумУпл164.СумНалОб.РеалСрок1511_118.НалБаза.ToDecimal());
        }
    }
}