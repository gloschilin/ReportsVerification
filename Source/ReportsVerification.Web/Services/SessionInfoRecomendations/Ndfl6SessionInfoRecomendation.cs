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
    public class Ndfl6SessionInfoRecomendation : IConcreteSessionInfoRecomendation
    {
        private readonly IReportInfoFactory _reportInfoFactory;

        public Ndfl6SessionInfoRecomendation(IReportInfoFactory reportInfoFactory)
        {
            _reportInfoFactory = reportInfoFactory;
        }

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (sessionInfo.Category == Categories.OooEmployer
                || sessionInfo.Category == Categories.AoEmployer
                || sessionInfo.Category == Categories.IpEmployer)
            {
                return new[] { 1, 2, 3 }.Select(
                    e => _reportInfoFactory.CreateReportInfoRevision(
                        ReportTypes.Ndfl6,
                        new DateOfQuarter(2017, e),
                        string.Empty, string.Empty, 0));
            }

            return new List<ReportInfo>();
        }
    }
}