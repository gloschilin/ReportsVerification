using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
    public class SessionInfoRecomedation7
        : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation7(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return
                sessionInfo.Category == Categories.OooEmployer
                || sessionInfo.Category == Categories.AoEmployer
                || sessionInfo.Category == Categories.IpEmployer;
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
            var vz = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.DeclarationOnIncomeTax,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            var nd6 = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.Ndfl6,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            var szvm = Enumerable.Range(1, 12)
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.SzvM,
                    new DateOfMonth(2017, e), string.Empty, string.Empty, 0));

            var fss4 = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.Fss4,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            return fss4.Union(szvm).Union(nd6).Union(vz);
        }
    }
}