using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
    public class SessionInfoRecomedation6
        : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation6(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return sessionInfo.Mode == UserModes.USN;
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
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
            }.Union(usn);
        }
    }
}