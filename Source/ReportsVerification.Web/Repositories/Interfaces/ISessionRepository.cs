using System;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий обработки данных сессии
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Создать сессию
        /// </summary>
        /// <param name="sessionInfo"></param>
        void Save(SessionInfo sessionInfo);

        /// <summary>
        /// Получить данные сессии
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SessionInfo Get(Guid id);
    }
}
