using System;
using log4net;
using log4net.Config;

namespace ReportsVerification.Web.Utills
{
    public class AppLog  : IAppLog
    {
        private readonly ILog _log4Net;
        private static IAppLog _instance;

        public static IAppLog Instance()
        {
            return _instance ?? (_instance = new AppLog());
        }

        private AppLog()
        {
            _log4Net = LogManager.GetLogger("LOGGER");
            XmlConfigurator.Configure();
        }

        public  void Error(string message, Exception ex)
        {
            _log4Net.Error(message, ex);
        }

        public  void Error(string message)
        {
            _log4Net.Error(message);
        }

        public  void Info(string message)
        {
            _log4Net.Info(message);
        }
    }
}