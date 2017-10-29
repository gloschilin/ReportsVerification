using System;
using System.Web.Http;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Repositories.Interfaces;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Контроллер для обработки данных сессии
    /// </summary>
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

        [Route("~/api/sessions")]
        [HttpPost]
        public SessionInfoModel Save(SessionInfoModel model)
        {
            var id = Guid.NewGuid();
            var info = new SessionInfo(id, model.UserId);
            _sessionRepository.Save(info);
            _modelMapper.Map(info, model);
            return model;
        }

        [Route("~/api/sessions/{sessionId}")]
        [HttpPut]
        public SessionInfoModel Update([FromUri]Guid sessionId, [FromBody]SessionInfoModel model)
        {
            var session = _sessionRepository.Get(sessionId);
            _dataMapper.Map(model, session);
            return model;
        }

        [Route("~/api/sessions/{sessionId}")]
        public SessionInfoModel Get(Guid sessionId)
        {
            var info = _sessionRepository.Get(sessionId);
            var model = new SessionInfoModel();
            _modelMapper.Map(info, model);
            return model;
        }
    }
}
