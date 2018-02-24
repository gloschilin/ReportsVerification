using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
    public abstract class CommonSessionInfoRecomedation
        : IConcreteSessionInfoRecomendation
    {
        protected abstract bool Condition(SessionInfo sessionInfo);

        public IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo)
        {
            if (Condition(sessionInfo))
            {
                return GetRecomendatedReportsIntenral();
            }
            return new List<ReportInfo>();
        }

        protected abstract IEnumerable<ReportInfo> GetRecomendatedReportsIntenral();
    }

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

    /// <summary>
    /// 6-ОСНО + ЕНВД
    /// </summary>
    public class SessionInfoRecomedation4
        : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation4(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return sessionInfo.Mode == UserModes.OSNOvsENVD;
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
            var nds = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.Nds,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            var tax = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(
                    ReportTypes.DeclarationOnIncomeTax,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            var envd = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(
                    ReportTypes.Envd,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            return new[]
            {
                _factory.CreateReportInfoRevision(ReportTypes.AccountingStatement,
                    new DateOfQuarter(2017, 4),
                    string.Empty, string.Empty, 0)
            }.Union(envd).Union(tax).Union(nds);
        }
    }

    /// <summary>
    /// 1-ЕНВД
    /// </summary>
    public class SessionInfoRecomedation3
        : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation3(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return sessionInfo.Mode == UserModes.ENVD;
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
            var encd = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(
                    ReportTypes.Envd,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            return new[]
            {
                _factory.CreateReportInfoRevision(ReportTypes.AccountingStatement,
                    new DateOfQuarter(2017, 4),
                    string.Empty, string.Empty, 0)
            }.Union(encd);
        }
    }


    /// <summary>
    /// 3-ОСНО(и при этом ответ на вопрос № 3 от 1 до 4)
    /// </summary>
    public class SessionInfoRecomedation2
        : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation2(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return sessionInfo.Mode == UserModes.OSNO
                   && (sessionInfo.Category == Categories.OooEmployer
                       || sessionInfo.Category == Categories.OooWithoutEmployees
                       || sessionInfo.Category == Categories.AoEmployer
                       || sessionInfo.Category == Categories.AoWithoutEmployees);
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
            var dt = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.DeclarationOnIncomeTax,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            var nds = new[] { 1, 2, 3, 4 }
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.Nds,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            return new[]
            {
                _factory.CreateReportInfoRevision(ReportTypes.AccountingStatement,
                    new DateOfQuarter(2017, 4),
                    string.Empty, string.Empty, 0)
            }.Union(dt).Union(nds);
        }
    }

    /// <summary>
    /// 3-ОСНО ( и при этом ответ на вопрос № 3 от 5 и 6)
    /// </summary>
    public class SessionInfoRecomedation1
    : CommonSessionInfoRecomedation
    {
        private readonly IReportInfoFactory _factory;

        public SessionInfoRecomedation1(IReportInfoFactory factory)
        {
            _factory = factory;
        }

        protected override bool Condition(SessionInfo sessionInfo)
        {
            return sessionInfo.Mode == UserModes.OSNO
                   && (sessionInfo.Category == Categories.IpEmployer
                       || sessionInfo.Category == Categories.IpWithoutEmployees);
        }

        protected override IEnumerable<ReportInfo> GetRecomendatedReportsIntenral()
        {
            var nds = new[] {1, 2, 3, 4}
                .Select(e => _factory.CreateReportInfoRevision(ReportTypes.Nds,
                    new DateOfQuarter(2017, e), string.Empty, string.Empty, 0));

            return new[]
            {
                _factory.CreateReportInfoRevision(ReportTypes.AccountingStatement,
                    new DateOfQuarter(2017, 4),
                    string.Empty, string.Empty, 0)
            }.Union(nds);
        }
    }
}