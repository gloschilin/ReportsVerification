using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Validation.Common;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributionsVsSzvm.Common
{
    public abstract class CommonCalculationContributionsVsSzvmValidator : CommonConcreteReportValidator
    {
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
                (DataObjects.Xsd.CalculationContributions.Файл)calculationContributionsReport.XsdReport;

            var complementarySzvMReportXsd = (DataObjects.Xsd.Szvm.ЭДПФР)complementarySzvMReport?.XsdReport;
            var cancelingSzvMReportXsd = (DataObjects.Xsd.Szvm.ЭДПФР)cancelingSzvMReport?.XsdReport;

            return false; //calculationContributionsReportXsd.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.
        }
    }
}