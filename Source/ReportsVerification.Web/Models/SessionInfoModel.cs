using System;
using ReportsVerification.Web.DataObjects.Enums;

namespace ReportsVerification.Web.Models
{
    /// <summary>
    /// Модель данных информации о сессии пользователя
    /// </summary>
    public class SessionInfoModel
    {
        /// <summary>
        /// Идментификатор сессии
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Категория пользователя
        /// </summary>
        public Categories? Category { get; set; }

        /// <summary>
        /// Режим пользователя
        /// </summary>
        public UserModes? Mode { get; set; }

        /// <summary>
        /// Регион пользователя
        /// </summary>
        public Guid? RegionId { get; set; }
    }
}