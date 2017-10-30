using System;

namespace ReportsVerification.Web.DataObjects.Catalogs
{
    /// <summary>
    /// Безопасная доля вычетов в декларации по НДС
    /// </summary>
    public class Deduction
    {
        /// <summary>
        /// Регион
        /// </summary>
        public Guid RegionId { get; set; }

        /// <summary>
        /// Значение на 1 квартал
        /// </summary>
        public decimal FirstQuaterAmount { get; set; }

        /// <summary>
        /// Значение на 2 квартал
        /// </summary>
        public decimal SecondQuaterAmount { get; set; }

        /// <summary>
        /// Значение на 3 квартал
        /// </summary>
        public decimal ThirdQuaterAmount { get; set; }

        /// <summary>
        /// Значение на 4 квартал
        /// </summary>
        public decimal ForthQuaterAmount { get; set; }
    }
}