using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class ReportsRecomendations : IReportsRecomendations
    {
        private readonly IEnumerable<IReportsConcreteRecomendations> _recomendations;

        public ReportsRecomendations(IEnumerable<IReportsConcreteRecomendations> recomendations)
        {
            _recomendations = recomendations;
        }

        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return _recomendations.SelectMany(e => e.GetRecomendations(reports)).Distinct();
        }
    }
}