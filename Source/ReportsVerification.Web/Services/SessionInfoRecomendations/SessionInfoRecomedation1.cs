﻿using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Dates;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Services.SessionInfoRecomendations
{
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