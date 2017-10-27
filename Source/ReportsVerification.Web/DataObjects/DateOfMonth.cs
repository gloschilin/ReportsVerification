namespace ReportsVerification.Web.DataObjects
{
    /// <summary>
    /// Дата ГОД/МЕСЯЦ
    /// </summary>
    public class DateOfMonth
    {
        public DateOfMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }

        /// <summary>
        /// Месяц
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; }
    }
}