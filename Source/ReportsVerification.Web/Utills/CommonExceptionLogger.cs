using System.Web.Http.ExceptionHandling;

namespace ReportsVerification.Web.Utills
{
    public class CommonExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            AppLog.Instance().Error("Application Error:", context.ExceptionContext.Exception);
            base.Log(context);
        }
    }
}