using System;

namespace ReportsVerification.Web.DataObjects.Dates
{
    /// <summary>
    ///     Формат даты в виде Год, Квартал
    /// </summary>
    public class DateOfQuarter: IDateType
    {
        public bool Equals(DateOfQuarter other)
        {
            return Year == other.Year && Quarter == other.Quarter;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is DateOfQuarter && Equals((DateOfQuarter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Year * 397) ^ Quarter.GetHashCode();
            }
        }

        public DateTime GetStartPeriodDate()
        {
            return ToStartQuarterDate();
        }

        /// <summary>
        ///     Год
        /// </summary>
        public int Year { get; }

        /// <summary>
        ///     Квартал
        /// </summary>
        public int Quarter { get; }

        public DateOfQuarter()
        {
            
        }

        public DateOfQuarter(int year, int quarter)
        {
            Year = year;
            Quarter = quarter;
        }

        public DateOfQuarter(DateTime date)
        {
            var year = date.Year;
            var quarter = (date.Month - 1) / 3 + 1;

            Year = year;
            Quarter = (byte) quarter;
        }

        /// <summary>
        ///     Возвращает дату начала квартала
        /// </summary>
        /// <returns></returns>
        public DateTime ToStartQuarterDate()
        {
            return new DateTime(Year, Quarter * 3 - 2, 1);
        }

        /// <summary>
        ///     Возвращает дату окончания квартала (день месяца первый)
        /// </summary>
        /// <returns></returns>
        public DateTime ToEndQuarterDate()
        {
            return new DateTime(Year, Quarter * 3, DateTime.DaysInMonth(Year, Quarter * 3));
        }

        /// <summary>
        ///     Является ли месяц последним месяцем квартала
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static bool IsQuarterMonth(int month)
        {
            return month == 3 || month == 6 || month == 9 || month == 12;
        }

        /// <summary>
        ///     Получить предыдущий квартал
        /// </summary>
        /// <returns></returns>
        public DateOfQuarter GetPrevious()
        {
            return Quarter == 1 ? new DateOfQuarter(Year - 1, 4) : new DateOfQuarter(Year, (byte) (Quarter - 1));
        }

        /// <summary>
        ///     Получить следующий квартал
        /// </summary>
        /// <returns></returns>
        public DateOfQuarter GetNext()
        {
            return Quarter == 4 ? new DateOfQuarter(Year + 1, 1) : new DateOfQuarter(Year, (byte) (Quarter + 1));
        }

        public static bool operator ==(DateOfQuarter value1, DateOfQuarter value2)
        {
            return value1?.Year == value2?.Year && value1?.Quarter == value2?.Quarter;
        }

        public static bool operator !=(DateOfQuarter value1, DateOfQuarter value2)
        {
            return !(value1 == value2);
        }

        public static bool operator >(DateOfQuarter value1, DateOfQuarter value2)
        {
            return value1.Year > value2.Year
                   || (value1.Year == value2.Year && value1.Quarter > value2.Quarter);
        }

        public static bool operator <(DateOfQuarter value1, DateOfQuarter value2)
        {
            return value1.Year < value2.Year
                   || (value1.Year == value2.Year && value1.Quarter < value2.Quarter);
        }

        public static bool operator >=(DateOfQuarter value1, DateOfQuarter value2)
        {
            return value1.Year > value2.Year
                   || (value1.Year == value2.Year && value1.Quarter >= value2.Quarter);
        }

        public static bool operator <=(DateOfQuarter value1, DateOfQuarter value2)
        {
            return value1.Year < value2.Year
                   || (value1.Year == value2.Year && value1.Quarter <= value2.Quarter);
        }

        public override string ToString()
        {
            return $"{Year}-{Quarter}";
        }
    }
}