using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
    /// <summary>
    /// Рекомандации для загрузки отчета ЕНВД
    /// </summary>
    public class EndvSessionInfoRecomendations: IConcreteSessionInfoRecomendation
    {
        private readonly IReportInfoFactory _reportInfoFactory;

        public EndvSessionInfoRecomendations(IReportInfoFactory reportInfoFactory)
        {
            _reportInfoFactory = reportInfoFactory;
        }

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (sessionInfo.Mode == UserModes.Envd
                || sessionInfo.Mode == UserModes.OsnoWithEnvd
                || sessionInfo.Mode == UserModes.UsnWitnEnvd
                || sessionInfo.Mode == UserModes.EshnWithEnvd)
            {
                return new[] { 1, 2, 3 }.Select(
                    e => _reportInfoFactory.CreateReportInfoRevision(
                        ReportTypes.Envd,
                        new DateOfQuarter(2017, e),
                        string.Empty, string.Empty, 0)
                    );
            }

            return new List<ReportInfo>();
        }
    }
}