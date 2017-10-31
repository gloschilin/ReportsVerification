using System;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Practices.ServiceLocation;
using ReportsVerification.Web.Repositories.Interfaces;

namespace ReportsVerification.Web.Utills.Attributes
{
    /// <summary>
    /// Атрибут проверяет наличе сессии
    /// </summary>
    public class CheckSessionActionFilterAttribute : ActionFilterAttribute
    {
        private const string SessionIdRouteParameterName = "sessionId";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var sessionRepository = ServiceLocator.Current.GetInstance<ISessionRepository>();
            object sessionIdobject;
            Guid sessionId;
            if (!actionContext.ActionArguments.TryGetValue(SessionIdRouteParameterName, out sessionIdobject)
                || !Guid.TryParse(sessionIdobject.ToString(), out sessionId))
            {
                throw new ApplicationException(
                    "Атрибут CheckSessionActionFilterAttribute установлен на методе " +
                    $"не имеющего параметра {SessionIdRouteParameterName}");
            }

            var session = sessionRepository.Get(sessionId);
            if (session == null)
            {
                throw new HttpException((int)HttpStatusCode.NotAcceptable, "Сессия не найдена");
            }

            base.OnActionExecuting(actionContext);
        }
    }
}