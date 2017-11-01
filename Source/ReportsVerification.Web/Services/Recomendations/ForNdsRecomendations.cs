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
    /// Рекомендации для загрузки НДС
    /// </summary>
    public class ForNdsRecomendations : IConcreteRecomendation
    {
        private static readonly IEnumerable<UserModes> Modes = new[]
        {
            UserModes.Osno, UserModes.OsnoWithEnvd,
        };

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (Modes.All(e=> e != sessionInfo.Mode))
            {
                return new List<ReportInfo>();
            }

            return new[] { 1, 2, 3 }.Select(
                e=>new ReportInfoRevistion<DateOfQuarter>(
                    ReportTypes.Nds, 
                    new DateOfQuarter(2017, e), 
                    string.Empty, 0));
        }
    }

}