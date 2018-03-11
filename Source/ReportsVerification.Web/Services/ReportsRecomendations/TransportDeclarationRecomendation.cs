using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.ReportsRecomendations
{
    public class UsnRecomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.Usn)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.UsnRecomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }

    public class TransportDeclarationRecomendation : IReportsConcreteRecomendations
    {
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports)
        {
            return reports.Any(e => e.Type == ReportTypes.TransportDeclaration)
                ? new List<ReportsRecomendationTypes> { ReportsRecomendationTypes.TransportDeclarationRecomendation }
                : new List<ReportsRecomendationTypes>();
        }
    }
}