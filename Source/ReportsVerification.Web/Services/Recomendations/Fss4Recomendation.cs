using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.DateOfMonthType;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.Recomendations
{
    public class Fss4Recomendation : IConcreteRecomendation
    {
        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (sessionInfo.Category == Categories.OooEmployer
                || sessionInfo.Category == Categories.AoEmployer
                || sessionInfo.Category == Categories.IpEmployer)
            {
                return new[] { 1, 2, 3 }.Select(
                    e => new ReportInfo(
                        ReportTypes.Fss4,
                        new DateOfMonth(2017, e),
                        string.Empty));
            }

            return new List<ReportInfo>();
        }
    }
}