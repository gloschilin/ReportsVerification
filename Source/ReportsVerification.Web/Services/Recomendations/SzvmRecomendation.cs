using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.Recomendations
{
    public class SzvmRecomendation : IConcreteRecomendation
    {
        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (sessionInfo.Category == Categories.OooEmployer
                || sessionInfo.Category == Categories.AoEmployer
                || sessionInfo.Category == Categories.IpEmployer)
            {
                return Enumerable.Range(1, 9).Select(
                    e => new SzvMReportInfo(
                        ReportTypes.SzvM,
                        new DateOfMonth(2017, e),
                        string.Empty, SzvMReportInfoType.Initial));
            }

            return new List<ReportInfo>();
        }
    }
}