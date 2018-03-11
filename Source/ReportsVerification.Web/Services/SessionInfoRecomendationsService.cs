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

            var result = new List<ReportInfo>();

            foreach (var report in recomedationReports)
            {
                if (result.All(e => !EqualsInfo(report, e)))
                {
                    result.Add(report);
                }
            }

            return result;
        }

        private static bool EqualsInfo(ReportInfo report, ReportInfo reportInfo)
        {
            return report.GetUniq() == reportInfo.GetUniq();
        }
    }
}