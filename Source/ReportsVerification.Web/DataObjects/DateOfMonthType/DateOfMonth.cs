namespace ReportsVerification.Web.DataObjects.DateOfMonthType
{
    /// <summary>
    /// Дата ГОД/МЕСЯЦ
    /// </summary>
    public partial class DateOfMonth
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

        private static int GetMonthFromQuarter(int quarter)
        {
            var month = quarter * 3 - 2;
            return month;
        }
    }
}