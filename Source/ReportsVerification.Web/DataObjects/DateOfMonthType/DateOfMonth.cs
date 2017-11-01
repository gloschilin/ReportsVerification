namespace ReportsVerification.Web.DataObjects.DateOfMonthType
{
    /// <summary>
    /// Дата ГОД/МЕСЯЦ
    /// </summary>
    public partial class DateOfMonth
    {
        

        public override int GetHashCode()
        {
            unchecked
            {
                return (Month*397) ^ Year;
            }
        }

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

        public static int GetMonthFromQuarter(int quarter)
        {
            var month = quarter * 3 - 2;
            return month;
        }

        public int GetQuarter()
        {
            return (Month - 1) / 3 + 1;
        }

        public static bool operator ==(DateOfMonth value1, DateOfMonth value2)
        {
            return value1?.Month == value2?.Month 
                && value1?.Year == value2?.Year;
        }

        public static bool operator !=(DateOfMonth value1, DateOfMonth value2)
        {
            return value1?.Month != value2?.Month
                || value1?.Year != value2?.Year;
        }

        protected bool Equals(DateOfMonth other)
        {
            return Month == other.Month && Year == other.Year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DateOfMonth)obj);
        }
    }
}