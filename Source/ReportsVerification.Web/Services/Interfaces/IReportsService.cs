using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

namespace ReportsVerification.Web.Services.Interfaces
{
    /// <summary>
    /// Сервис обработки отчетов
    /// </summary>
    public interface IReportsService
    {
        /// <summary>
        /// Получить отчеты, рекомендуемые к загрузке
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        IEnumerable<ReportInfo> GetMissingReports(Guid sessionId);

        /// <summary>
        /// Полоучить отчеты загруженные пользователем
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        IEnumerable<ReportInfo> GetReports(Guid sessionId);

        /// <summary>
        /// Сохранить отчет
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        void Save(Guid sessionId, string fileName, string fileContent);


        /// <summary>
        /// Сохранить данные некорректного отчета
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        /// <param name="errorMessage"></param>
        void SaveWrongReport(Guid sessionId, string fileName, string fileContent, string errorMessage);
    }
}