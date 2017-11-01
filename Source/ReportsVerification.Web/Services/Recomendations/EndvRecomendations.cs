using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.Recomendations
{
    /// <summary>
    /// Рекомандации для загрузки отчета ЕНВД
    /// </summary>
    public class EndvRecomendations: IConcreteRecomendation
    {
        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (sessionInfo.Mode == UserModes.Envd
                || sessionInfo.Mode == UserModes.OsnoWithEnvd
                || sessionInfo.Mode == UserModes.UsnWitnEnvd
                || sessionInfo.Mode == UserModes.EshnWithEnvd)
            {
                return new[] { 1, 2, 3 }.Select(
                    e => new ReportInfoRevistion<DateOfQuarter>(
                        ReportTypes.Envd,
                        new DateOfQuarter(2017, e),
                        string.Empty, 0));
            }

            return new List<ReportInfo>();
        }
    }
}