using System;
using System.Data.Entity;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Repositories.EF;
using ReportsVerification.Web.Repositories.Interfaces;

namespace ReportsVerification.Web.Repositories
{
    internal class SessionMapper: IEntityMapper<SessionInfo, Session, ReportsVertification>, IMapper<Session, SessionInfo>
    {
        public void Map(Session source, SessionInfo destination)
        {
            throw new NotImplementedException();
        }

        public void Map(SessionInfo source, Session destination, ReportsVertification context)
        {
            destination.Id = source.Id;
            destination.UserId = source.ActionUserId;
            destination.DateCreate = DateTime.Now;
            destination.RegionId = source.RegionId;

            if (source.Category.HasValue)
            {
                var categoryEntity = context.Categories.FirstOrDefault(e => e.Alias == source.Category.ToString());
                if (categoryEntity == null)
                {
                    throw new ApplicationException("Неизвестный тип категории");
                }
                destination.CategoryId = categoryEntity.Id;
            }
            else
            {
                destination.CategoryId = null;
            }

            if (source.Mode.HasValue)
            {
                var modeEntity = context.Modes.FirstOrDefault(e => e.Alias == source.Mode.ToString());
                if (modeEntity == null)
                {
                    throw new ApplicationException("Неизвестный режим пользователя");
                }

                destination.ModeId = modeEntity.Id;
            }
        }
    }

    /// <summary>
    /// Репозиторий данных сессий
    /// </summary>
    public class SessionRepository: ISessionRepository
    {
        private readonly IMapper<SessionInfo, Session> _toEntityMapper;
        private readonly IMapper<Session, SessionInfo> _fromEntityMapper;

        public SessionRepository(
            IMapper<SessionInfo, Session> toEntityMapper, 
            IMapper<Session, SessionInfo> fromEntityMapper)
        {
            _toEntityMapper = toEntityMapper;
            _fromEntityMapper = fromEntityMapper;
        }

        public void Save(SessionInfo sessionInfo)
        {
            using (var context = new ReportsVertification())
            {
                var dbEntity = context.Sessions.FirstOrDefault(e => e.Id == sessionInfo.Id) ?? new Session();
                _toEntityMapper.Map(sessionInfo, dbEntity);
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