using System;
using System.Net;
using System.Web;
using System.Web.Http;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Utills.Attributes;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Контроллер для обработки данных сессии
    /// </summary>
    [ControllerSettings(allowCamelCase: true)]
    public class SessionController : ApiController
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper<SessionInfoModel, SessionInfo> _dataMapper;
        private readonly IMapper<SessionInfo, SessionInfoModel> _modelMapper;

        public SessionController(ISessionRepository sessionRepository,
            IMapper<SessionInfoModel, SessionInfo> dataMapper,
            IMapper<SessionInfo, SessionInfoModel> modelMapper)
        {
            _sessionRepository = sessionRepository;
            _dataMapper = dataMapper;
            _modelMapper = modelMapper;
        }

        [Route("~/api/sessions"), HttpPost]
        public SessionInfoModel AddNewSession(SessionInfoModel model)
        {
            var id = Guid.NewGuid();
            var info = new SessionInfo(id, model.UserId);
            _sessionRepository.Save(info);
            _modelMapper.Map(info, model);
            return model;
        }

        [Route("~/api/sessions/{sessionId}"), HttpPut, CheckSessionActionFilter]
        public SessionInfoModel UpdateSession(Guid sessionId, SessionInfoModel model)
        {
            if (model.Id != sessionId)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest,
                    "Значения идентификатора сессии в заголовке и теле запроса не совпадают");
            }

            var session = _sessionRepository.Get(model.Id);

            if (session.ActionUserId != model.UserId)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, 
                    "Неверное значение дентификатора пользователя");
            }

            _dataMapper.Map(model, session);
            _sessionRepository.Save(session);
            return model;
        }

        [Route("~/api/sessions/{sessionId}"), HttpGet, CheckSessionActionFilter]
        public SessionInfoModel Get(Guid sessionId)
        {
            var info = _sessionRepository.Get(sessionId);
            var model = new SessionInfoModel();
            _modelMapper.Map(info, model);
            return model;
        }
    }
}
