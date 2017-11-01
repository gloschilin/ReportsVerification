using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    public interface IReportRepository
    {
        void Save(Guid sessionId, string fileName, Report report);
        void SaveWrongReport(Guid sessionId, string fileName, string wrongMessage, string content);

        IEnumerable<Report> GetList(Guid sessionId);
    }
}
