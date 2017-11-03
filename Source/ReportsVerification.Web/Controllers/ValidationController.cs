using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ReportsVerification.Web.Models;
using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Controllers
{
    /// <summary>
    /// Контроллер для валидации отчетов загруженных пользователем
    /// </summary>
    public class ValidationController : ApiController
    {
        private readonly IReportsValidationService _reportsValidationService;
        private readonly IReportRepository _reportRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IValidationHandler _validationHandler;

        public ValidationController(
            IReportsValidationService reportsValidationService,
            IReportRepository reportRepository,
            ISessionRepository sessionRepository,
            IValidationHandler validationHandler)
        {
            _reportsValidationService = reportsValidationService;
            _reportRepository = reportRepository;
            _sessionRepository = sessionRepository;
            _validationHandler = validationHandler;
        }

        /// <summary>
        /// Получить проверку отчетов
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [Route("api/services/validation"), HttpGet]
        public IEnumerable<ValidationStepType> ValidateReports(Guid sessionId, ValidateRequestType type)
        {
            var reports = _reportRepository.GetList(sessionId).ToArray();
            var session = _sessionRepository.Get(sessionId);
            _reportsValidationService.Validate(reports, session);
            var validationResult = _validationHandler.GetWrongMessages();
            return validationResult;
        }
    }
}