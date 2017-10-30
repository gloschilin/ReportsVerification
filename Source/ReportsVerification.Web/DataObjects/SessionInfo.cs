using System;
using ReportsVerification.Web.DataObjects.Enums;

namespace ReportsVerification.Web.DataObjects
{
    public class SessionInfo
    {
        public SessionInfo(Guid id, int actionUserId)
        {
            Id = id;
            ActionUserId = actionUserId;
        }

        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Идентификатор пользователя в системе Id2 
        /// </summary>
        public int ActionUserId { get; }

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