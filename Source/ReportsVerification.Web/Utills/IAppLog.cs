using System;

namespace ReportsVerification.Web.Utills
{
    public interface IAppLog
    {
        void Error(string message, Exception ex);
        void Error(string message);
        void Info(string message);
    }
}