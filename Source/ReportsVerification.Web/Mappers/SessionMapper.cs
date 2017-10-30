using System;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Enums;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Repositories.EF;

namespace ReportsVerification.Web.Mappers
{
    public class SessionMapper: 
        IEntityMapper<SessionInfo, Session, ReportsVertification>, 
        IMapper<Session, SessionInfo>,
        IMapper<SessionInfoModel, SessionInfo>,
        IMapper<SessionInfo, SessionInfoModel>
    {
        public void Map(Session source, SessionInfo destination)
        {
            destination.RegionId = source.RegionId;
            if (source.CategoryId != null)
            {
                Categories category;
                if (!Enum.TryParse(source.Category.Alias, true, out category))
                {
                    throw new ApplicationException("Неизвестный тип категории");
                }
                destination.Category = category;
            }
            else
            {
                destination.Category = null;
            }

            if (source.ModeId.HasValue)
            {
                UserModes mode;
                if (!Enum.TryParse(source.Mode.Alias, true, out mode))
                {
                    throw new ApplicationException("Неизвестный тип режима пользователя");
                }
                destination.Mode = mode;
            }
            else
            {
                destination.Mode = null;
            }
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

        public void Map(SessionInfoModel source, SessionInfo destination)
        {
            destination.Category = source.Category;
            destination.Mode = source.Mode;
            destination.RegionId = source.RegionId;
        }

        public void Map(SessionInfo source, SessionInfoModel destination)
        {
            destination.Id = source.Id;
            destination.Category = source.Category;
            destination.Mode = source.Mode;
            destination.RegionId = source.RegionId;
            destination.UserId = source.ActionUserId;
        }
    }
}