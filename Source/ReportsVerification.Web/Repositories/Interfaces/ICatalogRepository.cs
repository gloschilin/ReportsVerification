using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects.Catalogs;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий каталогов системы
    /// </summary>
    public interface ICatalogRepository
    {
        /// <summary>
        /// Безопасная доля вычетов в декларации по НДС
        /// </summary>
        /// <param name="valuesOnDate"></param>
        /// <returns></returns>
        IEnumerable<Deduction> GetDeductions(DateTime valuesOnDate);

        /// <summary>
        /// Безопасная доля вычетов в декларации по НДС
        /// </summary>
        /// <param name="valuesOnDate"></param>
        /// <param name="regionId"></param>
        /// <returns></returns>
        Deduction GetDeduction(DateTime valuesOnDate, Guid regionId);

        /// <summary>
        /// Минимальный размер оплаты труда
        /// </summary>
        /// <param name="valuesOnDate"></param>
        /// <returns></returns>
        IEnumerable<Mrot> GetMrot(DateTime valuesOnDate);

        /// <summary>
        /// Минимальный размер оплаты труда
        /// </summary>
        /// <param name="valuesOnDate"></param>
        /// <param name="regionId"></param>
        /// <returns></returns>
        Mrot GetMrot(DateTime valuesOnDate, Guid regionId);
    }
}