using System;
using System.Collections.Generic;
using System.Web.Http;
using ReportsVerification.Web.Services.Interfaces;
using ReportsVerification.Web.Services.ReportsRecomendations;
using ReportsVerification.Web.Utills.Attributes;

namespace ReportsVerification.Web.Controllers
{
    [ControllerSettings(allowCamelCase: true)]
    public class RecomendationsController : ApiController
    {
        private readonly IReportsService _reportsService;

        public RecomendationsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }


        /// <summary>
        /// Получить рекомендации по загруженным отчетам
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [Route("api/services/recomendations"), HttpGet]
        public IEnumerable<ReportsRecomendationTypes> GetRecomendations(Guid sessionId)
        {
            return _reportsService.GeTrRecomendationsByExistsReports(sessionId);
        }
    }
}
