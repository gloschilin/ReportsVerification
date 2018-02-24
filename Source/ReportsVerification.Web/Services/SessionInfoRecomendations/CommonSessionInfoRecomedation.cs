using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
    public abstract class CommonSessionInfoRecomedation
        : IConcreteSessionInfoRecomendation
    {
        protected abstract bool Condition(SessionInfo sessionInfo);

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (Condition(sessionInfo))
            {
                return GetRecomendatedReportsIntenral();
            }
            return new List<ReportInfo>();
        }

        protected abstract IEnumerable<ReportInfo> GetRecomendatedReportsIntenral();
    }
}