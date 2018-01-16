using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ReportsVerification.Web.Filters;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Utills.Attributes;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Контроллер для валидации отчетов загруженных пользователем
    /// </summary>
    [ControllerSettings(allowCamelCase: true), AllowOptionsFilter]
    public class ValidationController : ApiController
    {
        private readonly IReportsValidator _reportsValidator;
        private readonly IReportRepository _reportRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IValidationContext _validationContext;

        public ValidationController(
            IReportsValidator reportsValidator,
            IReportRepository reportRepository,
            ISessionRepository sessionRepository,
            IValidationContext validationContext)
        {
            _reportsValidator = reportsValidator;
            _reportRepository = reportRepository;
            _sessionRepository = sessionRepository;
            _validationContext = validationContext;
        }

        /// <summary>
        /// Получить проверку отчетов
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [Route("api/services/validation"), HttpGet]
        public IEnumerable<ValidationStepType> ValidateReports(Guid sessionId)
        {
            var reports = _reportRepository.GetList(sessionId).ToArray();
            var session = _sessionRepository.Get(sessionId);

            if (session == null)
            {
                throw new HttpException(403, "Доступ запрещен. Указанная сессия не найдена.");
            }

            _reportsValidator.Validate(reports, session);
            var validationResult = _validationContext.GetWrongMessages(sessionId);
            return validationResult;
        }
    }
}
