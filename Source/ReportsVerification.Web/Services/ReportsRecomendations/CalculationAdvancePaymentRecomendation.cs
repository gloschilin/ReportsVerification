using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class CalculationAdvancePaymentRecomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.CalculationAdvancePayment)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.CalculationAdvancePaymentRecomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }
}