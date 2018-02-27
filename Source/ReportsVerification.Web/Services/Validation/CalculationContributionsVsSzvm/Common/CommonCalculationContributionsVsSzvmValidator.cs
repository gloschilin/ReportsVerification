using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common
{
    public abstract class CommonCalculationContributionsVsSzvmValidator : CommonConcreteReportValidator
    {
        public override ReportTypes[] ReportTypesSupport => new[]
        {
            ReportTypes.CalculationContributions,
            ReportTypes.SzvM
        };

        protected abstract int CalculationContributionsQuarter { get; }
        protected abstract int SzvmMonth { get; }

        protected CommonCalculationContributionsVsSzvmValidator(IValidationContext context) : base(context)
        {

        }

        protected override bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var initialSzvMReport = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as SzvMReportInfo;
                return info != null 
                    && info.Type == ReportTypes.SzvM
                    && info.ReportMoth.Month == SzvmMonth 
                    && info.SzvMType == SzvMReportInfoType.Initial;
            });

            if (initialSzvMReport == null)
            {
                return true;
            }

            var calculationContributionsReport = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                return info != null 
                       && e.ReportType == ReportTypes.CalculationContributions
                       && info.ReportPeriod.Quarter == CalculationContributionsQuarter;
            });

            if (calculationContributionsReport == null)
            {
                return true;
            }

            var complementarySzvMReport = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as SzvMReportInfo;
                return info != null
                    && info.Type == ReportTypes.SzvM
                    && info.ReportMoth.Month == SzvmMonth
                    && info.SzvMType == SzvMReportInfoType.Complementary;
            });

            var cancelingSzvMReport = reports.FirstOrDefault(e =>
            {
                var info = e.GetReportInfo() as SzvMReportInfo;
                return info != null
                    && info.Type == ReportTypes.SzvM
                    && info.ReportMoth.Month == SzvmMonth
                    && info.SzvMType == SzvMReportInfoType.Canceling;
            });

            var initialSzvMReportXsd = (DataObjects.Xsd.Szvm.ЭДПФР)initialSzvMReport.XsdReport;
            var calculationContributionsReportXsd = 
                (Файл)calculationContributionsReport.XsdReport;

            var complementarySzvMReportXsd = (DataObjects.Xsd.Szvm.ЭДПФР)complementarySzvMReport?.XsdReport;
            var cancelingSzvMReportXsd = (DataObjects.Xsd.Szvm.ЭДПФР)cancelingSzvMReport?.XsdReport;

            var ccAmount = calculationContributionsReportXsd.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС
                .Select(e => GetCount(e.РасчСВ_ОПС.КолСтрахЛицВс)).Sum();

            var initialTagsCount = initialSzvMReportXsd.СЗВМ.СписокЗЛ.Select(e => e.НомерПП).Count();
            var complementaryTagsCount = complementarySzvMReportXsd?.СЗВМ.СписокЗЛ.Select(e => e.НомерПП).Count() ?? 0;
            var cancelingTagsCount = cancelingSzvMReportXsd?.СЗВМ.СписокЗЛ.Select(e => e.НомерПП).Count() ?? 0;

            return ccAmount == initialTagsCount + complementaryTagsCount - cancelingTagsCount;
        }

        protected abstract int GetCount(КолЛицТип value);
    }
}