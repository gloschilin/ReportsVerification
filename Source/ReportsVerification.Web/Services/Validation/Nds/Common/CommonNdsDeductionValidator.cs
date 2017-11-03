using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Catalogs;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.Nds;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Nds.Common
{
    public abstract class CommonNdsDeductionValidator: CommonConcreteReportValidator
    {
        private readonly ICatalogRepository _catalogRepository;
        protected abstract int Quarter { get; }

        protected CommonNdsDeductionValidator(IValidationContext context, ICatalogRepository catalogRepository) : base(context)
        {
            _catalogRepository = catalogRepository;
        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                return true;
            }

            foreach (var report in reports
                .Where(e => e.ReportType == ReportTypes.Nds)
                .Where(e => ((ReportInfoRevistion<DateOfQuarter>)e.GetReportInfo()).ReportPeriod.Quarter == Quarter)
                .Where(e => (e.XsdReport as Файл)?.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() > 0).ToList())
            {
                var file = (Файл)report.XsdReport;
                var deduction = _catalogRepository.GetDeduction(
                    report.GetReportInfo().GetStartReportPeriod(),
                    sessionInfo.RegionId.Value);

                var incorrect = file.Документ.НДС.СумУпл164.СумНалВыч.НалВычОбщ.ToDecimal()
                                / file.Документ.НДС.СумУпл164.СумНалОб.СумНалВосст.СумНалВс.ToDecimal() * 100
                                >= GetDeduction(deduction);

                if (incorrect)
                {
                    return false;
                }
            }

            return true;
        }

        protected abstract decimal GetDeduction(Deduction deduction);
    }
}