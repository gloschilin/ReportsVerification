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
        public override ReportTypes[] ReportTypesSupport => new[]
        {
            ReportTypes.Nds
        };

        private readonly ICatalogRepository _catalogRepository;
        protected abstract int Quarter { get; }

        protected CommonNdsDeductionValidator(IValidationContext context, ICatalogRepository catalogRepository) 
            : base(context)
        {
            _catalogRepository = catalogRepository;
        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (!sessionInfo.RegionId.HasValue)
            {
                return true;
            }

            var ndsReportByQuarter = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                return info != null && info.ReportPeriod.Quarter == Quarter;
            });

            if (ndsReportByQuarter == null)
            {
                return true;
            }

            var xsd = (Файл) ndsReportByQuarter.XsdReport;

            if (xsd.Документ.НДС.СумУплНП.СумПУ_1731.ToDecimal() <= 0)
            {
                return true;
            }

            var deduction = _catalogRepository.GetDeduction(
                ndsReportByQuarter.GetReportInfo().GetStartReportPeriod(),
                sessionInfo.RegionId.Value);

            var correct = xsd.Документ.НДС.СумУпл164.СумНалВыч.НалВычОбщ.ToDecimal()
                          / xsd.Документ.НДС.СумУпл164.СумНалОб.СумНалВосст.СумНалВс.ToDecimal() * 100m
                          >= GetDeduction(deduction);

            return correct;
        }

        protected abstract decimal GetDeduction(Deduction deduction);
    }
}