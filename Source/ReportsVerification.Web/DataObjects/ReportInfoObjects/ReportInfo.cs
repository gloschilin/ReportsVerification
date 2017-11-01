using System;
using System.Security.Cryptography;
using System.Text;

namespace ReportsVerification.Web.DataObjects.ReportInfoObjects
{
    /// <summary>
    /// Базовая информация отчета
    /// </summary>
    public abstract class ReportInfo
    {
        protected ReportInfo(ReportTypes type, string companyName)
        {
            Type = type;
            CompanyName = companyName;
        }

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string CompanyName { get; }

        /// <summary>
        /// Тип отчета
        /// </summary>
        public ReportTypes Type { get; }

        public abstract string GetUniq();

        public abstract DateTime GetStartReportPeriod();

        protected static string GetHash(HashAlgorithm md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}