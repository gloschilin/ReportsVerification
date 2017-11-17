using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class Fss4Recomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.Fss4)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.Fss4Recomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }
}