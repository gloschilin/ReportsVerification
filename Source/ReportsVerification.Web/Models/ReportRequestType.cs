namespace ReportsVerification.Web.Models
{
    /// <summary>
    /// Тип запроса на получение отчетов
    /// </summary>
    public enum ReportRequestType
    {
        /// <summary>
        /// Существующие (загруженные)
        /// </summary>
        Exists,

        /// <summary>
        /// Недостающие
        /// </summary>
        Missing
    }
}