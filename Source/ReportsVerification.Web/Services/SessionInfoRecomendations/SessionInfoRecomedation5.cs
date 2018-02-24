using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
    /// <summary>
    /// 7-УСН + ЕНВД
    /// </summary>
    public class SessionInfoRecomedation5
        : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation5(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return sessionInfo.Mode == UserModes.USNvsENVD;
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
            var envd = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(
                    ReportTypes.Envd,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            var usn = new[]
            {
                _factory.CreateReportInfoRevision(ReportTypes.Usn,
                    new DateOfQuarter(2017, 4),
                    string.Empty, string.Empty, 0)
            };

            return new[]
            {
                _factory.CreateReportInfoRevision(ReportTypes.AccountingStatement,
                    new DateOfQuarter(2017, 4),
                    string.Empty, string.Empty, 0)
            }.Union(envd).Union(usn);
        }
    }
}