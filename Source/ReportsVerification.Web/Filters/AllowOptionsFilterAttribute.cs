using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ReportsVerification.Web.Filters
{
    public class AllowOptionsFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Method == HttpMethod.Options)
            {
                actionContext.Response.StatusCode = HttpStatusCode.OK;
                return;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}