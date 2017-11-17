using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class DeclarationOnPropertyTaxRecomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.DeclarationOnPropertyTax)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.DeclarationOnPropertyTaxRecomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }
}