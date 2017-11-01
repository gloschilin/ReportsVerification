using System.Security.Cryptography;
using System.Text;
using ReportsVerification.Web.DataObjects.DateOfMonthType;

namespace ReportsVerification.Web.DataObjects.ReportInfoObjects
{
    /// <summary>
    /// Типы отчетов СЗВ-М
    /// </summary>
    public enum SzvMReportInfoType
    {
        /// <summary>
        /// Исходная
        /// </summary>
        Initial,

        /// <summary>
        /// Дополняющая
        /// </summary>
        Complementary,

        /// <summary>
        /// Отменяющая
        /// </summary>
        Canceling
    }

    /// <summary>
    /// Информация по отчету СЗВ-М
    /// </summary>
    public class SzvMReportInfo: ReportInfo
    {
        public SzvMReportInfoType SzvMType { get; }

        public SzvMReportInfo(ReportTypes type, DateOfMonth reportMonth, string companyName, 
            SzvMReportInfoType szvMType) 
            : base(type, reportMonth, companyName)
        {
            SzvMType = szvMType;
        }
    }

    /// <summary>
    /// Базовая информация отчета
    /// </summary>
    public class ReportInfo
    {
        public ReportInfo(ReportTypes type, DateOfMonth reportMonth, string companyName)
        {
            Type = type;
            ReportMonth = reportMonth;
            CompanyName = companyName;
        }

        /// <summary>
        /// Месяц отчета
        /// </summary>
        public DateOfMonth ReportMonth { get; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string CompanyName { get; }

        /// <summary>
        /// Тип отчета
        /// </summary>
        public ReportTypes Type { get; }

        public virtual string GetUniq()
        {
            var source = Type.ToString() + ReportMonth.Month + ReportMonth.Year;
            using (var md5Hash = MD5.Create())
            {
                var hash = GetHash(md5Hash, source);
                return hash;
            }
            
        }

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