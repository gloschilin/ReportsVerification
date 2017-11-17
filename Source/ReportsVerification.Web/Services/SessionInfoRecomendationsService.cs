using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services
{
    public class SessionInfoRecomendationsService : ISessionInfoRecomendationsService
    {
        private readonly IEnumerable<IConcreteSessionInfoRecomendation> _conditions;
        public SessionInfoRecomendationsService(IEnumerable<IConcreteSessionInfoRecomendation> conditions)
        {
            _conditions = conditions;
        }

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            var recomedationReports = _conditions.AsParallel()
                .SelectMany(e => e.GetRecomendatedReports(sessionInfo)).ToArray();
            return recomedationReports;
        }
    }
}