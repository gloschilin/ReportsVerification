using System;

namespace ReportsVerification.Web.DataObjects.Catalogs
{
    /// <summary>
    /// Минимальны размер оплаты труда в регионе
    /// </summary>
    public class Mrot
    {
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public Guid RegionId { get; set; }

        /// <summary>
        /// МРОТ
        /// </summary>
        public decimal Amount { get; set; }
    }
}