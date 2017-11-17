using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class AccountingReportingRecomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.AccountingStatementSimplifiedTaxation
                                    || e.Type == ReportTypes.AccountingStatement)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.AccountingReportingRecomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }
}