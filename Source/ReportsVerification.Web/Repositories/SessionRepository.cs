using System;
using System.Data.Entity;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Repositories.Interfaces;

namespace ReportsVerification.Web.Repositories
{
    /// <summary>
    /// Репозиторий данных сессий
    /// </summary>
    public class SessionRepository: ISessionRepository
    {
        private readonly IEntityMapper<SessionInfo, Session, ReportsVertification> _toEntityMapper;
        private readonly IMapper<Session, SessionInfo> _fromEntityMapper;

        public SessionRepository(
            IEntityMapper<SessionInfo, Session, ReportsVertification> toEntityMapper,
            IMapper<Session, SessionInfo> fromEntityMapper)
        {
            _toEntityMapper = toEntityMapper;
            _fromEntityMapper = fromEntityMapper;
        }

        public void Save(SessionInfo sessionInfo)
        {
            using (var context = new ReportsVertification())
            {
                var dbEntity = context.Sessions.FirstOrDefault(e => e.Id == sessionInfo.Id);
                if (dbEntity == null)
                {
                    dbEntity = new Session();
                    context.Sessions.Add(dbEntity);
                }
                _toEntityMapper.Map(sessionInfo, dbEntity, context);
                context.SaveChanges();
            }
        }


        public SessionInfo Get(Guid id)
        {
            using (var context = new ReportsVertification())
            {
                var dbEntity = context.Sessions.Include(e=>e.Category).Include(e=>e.Mode)
                    .FirstOrDefault(e => e.Id == id);
                if (dbEntity == null)
                {
                    return null;
                }

                var result = new SessionInfo(dbEntity.Id, dbEntity.UserId);
                _fromEntityMapper.Map(dbEntity, result);
                return result;
            }
        }
    }
}