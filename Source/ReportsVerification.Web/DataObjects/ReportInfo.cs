namespace ReportsVerification.Web.DataObjects
{
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
    }
}