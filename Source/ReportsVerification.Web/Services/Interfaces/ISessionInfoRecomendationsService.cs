using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

namespace ReportsVerification.Web.Services.Interfaces
{
    /// <summary>
    /// Обработка рекомендаций
    /// </summary>
    public interface ISessionInfoRecomendationsService
    {
        /// <summary>
        /// Получить отчеты рекомендуемые к загрузке
        /// </summary>
        /// <param name="sessionInfo"></param>
        /// <returns></returns>
        IEnumerable<ReportInfo> GetRecomendatedReports(SessionInfo sessionInfo);
    }
}
