using System.Collections.Generic;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Services.ReportsRecomendations;

namespace ReportsVerification.Web.Services.Interfaces
{
    /// <summary>
    /// Рекомендации по загруженным отчетам
    /// </summary>
    public interface IReportsRecomendations
    {
        IEnumerable<ReportsRecomendationTypes> GetRecomendations(IEnumerable<ReportInfo> reports);
    }
}
