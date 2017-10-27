using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    public interface IReportRepository
    {
        void Save(Guid sessionId, Report report);

        IEnumerable<Report> GetList(Guid sessionId);
    }
}
