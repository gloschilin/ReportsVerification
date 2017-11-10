using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Services.Interfaces
{
    /// <summary>
    /// Получение актуальных отчетов из списка переданных
    /// </summary>
    public interface IRevisionFilerService
    {
        /// <summary>
        /// Получение актуальных отчетов из списка переданных
        /// </summary>
        /// <param name="allReports"></param>
        /// <returns></returns>
        IEnumerable<Report> GetActualReports(IReadOnlyCollection<Report> allReports);
    }
}