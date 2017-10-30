using System;

namespace ReportsVerification.Web.DataObjects.Catalogs
{
    /// <summary>
    /// Данные региона
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}