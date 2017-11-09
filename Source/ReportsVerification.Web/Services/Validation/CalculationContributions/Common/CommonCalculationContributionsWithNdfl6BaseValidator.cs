using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.DataObjects.Xsd.CalculationContributions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.CalculationContributions.Common
{
    public abstract class CommonCalculationContributionsWithNdfl6BaseValidator
        : CommonCalculationContributionsValidator
    {
        protected CommonCalculationContributionsWithNdfl6BaseValidator(IValidationContext context) : base(context)
        {

        }

        protected override bool IsValid(Файл xsdReport, 
            IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            var ndflReport = reports.FirstOrDefault(e =>
            {
                var reportInfo = e.GetReportInfo() as ReportInfoRevistion<DateOfQuarter>;
                return reportInfo != null && reportInfo.ReportPeriod.Quarter == Quarter &&
                       reportInfo.Type == ReportTypes.Ndfl6;
            });

            if (ndflReport == null)
            {
                return true;
            }

            var ndfl6XsdReport = (DataObjects.Xsd.Ndfl6.Файл) ndflReport.XsdReport;

            return ndfl6XsdReport.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.First().НачислДох
                   - ndfl6XsdReport.Документ.НДФЛ6.ОбобщПоказ.СумСтавка.First().НачислДохДив
                   >= xsdReport.Документ.РасчетСВ.ОбязПлатСВ.РасчСВ_ОПС_ОМС.First().РасчСВ_ОПС.ВыплНачислФЛ.СумВсегоПер;
        }
    }
}