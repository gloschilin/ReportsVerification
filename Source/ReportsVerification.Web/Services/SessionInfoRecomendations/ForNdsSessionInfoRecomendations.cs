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
    /// Рекомендации для загрузки НДС
    /// </summary>
    public class ForNdsSessionInfoRecomendations : IConcreteSessionInfoRecomendation
    {
        private readonly IReportInfoFactory _reportInfoFactory;

        private static readonly IEnumerable<UserModes> Modes = new[]
        {
            UserModes.Osno, UserModes.OsnoWithEnvd,
        };

        public ForNdsSessionInfoRecomendations(IReportInfoFactory reportInfoFactory)
        {
            _reportInfoFactory = reportInfoFactory;
        }

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (Modes.All(e=> e != sessionInfo.Mode))
            {
                return new List<ReportInfo>();
            }

            return new[] { 1, 2, 3 }.Select(
                e=> _reportInfoFactory.CreateReportInfoRevision(
                    ReportTypes.Nds, new DateOfQuarter(2017, e), 
                    string.Empty, string.Empty, 0));
        }
    }

}