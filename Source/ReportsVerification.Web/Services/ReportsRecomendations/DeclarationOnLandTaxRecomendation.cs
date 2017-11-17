using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class DeclarationOnLandTaxRecomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.DeclarationOnLandTax)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.DeclarationOnLandTaxRecomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }
}