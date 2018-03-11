using System;
using System.Collections.Generic;

namespace ReportsVerification.Web.DataObjects.Dates
{
    /// <summary>
    ///     Формат даты в виде Месяц Год
    /// </summary>
    public class DateOfMonth
        : IComparable<DateOfMonth>, IDateType
    {
        /// <summary>
        ///     Год
        /// </summary>
        public int Year { get; }

        /// <summary>
        ///     Месяц
        /// </summary>
        public int Month { get; }

        public DateOfMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public DateOfMonth()
        {
            
        }

        public DateOfMonth(DateTime date) 
        {
            Year = (short)date.Year;
            Month = (byte)date.Month;
        }

        public DateTime GetStartMonthDate()
        {
            return new DateTime(Year, Month, 1);
        }

        public DateTime GetEndMonthDate()
        {
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
        }


        public static bool operator ==(DateOfMonth date1, DateOfMonth date2)
        {
            return date1?.Year == date2?.Year && date1?.Month == date2?.Month;
        }

        public static bool operator !=(DateOfMonth date1, DateOfMonth date2)
        {
            return !(date1 == date2);
        }

        public static bool operator <=(DateOfMonth date1, DateOfMonth date2)
        {
            return date1.Year < date2.Year || (date1.Year == date2.Year && date1.Month <= date2.Month);
        }

        public static bool operator >=(DateOfMonth date1, DateOfMonth date2)
        {
            return date1.Year > date2.Year || (date1.Year == date2.Year && date1.Month >= date2.Month);
        }

        public static bool operator <(DateOfMonth date1, DateOfMonth date2)
        {
            return date1.Year < date2.Year || (date1.Year == date2.Year && date1.Month < date2.Month);
        }

        public static bool operator >(DateOfMonth date1, DateOfMonth date2)
        {
            return date1.Year > date2.Year || (date1.Year == date2.Year && date1.Month > date2.Month);
        }

        public static IEnumerable<DateOfMonth> GetRange(DateOfMonth from, DateOfMonth to)
        {
            var result = new List<DateOfMonth>();

            while (from <= to)
            {
                result.Add(from);
                from = from.AddMonth(1);
            }
            return result;
        }

        public DateOfMonth AddMonth(byte month)
        {
            var date = GetStartMonthDate().AddMonths(month);
            return new DateOfMonth((short)date.Year, (byte)date.Month);
        }

        public bool Equals(DateOfMonth other)
        {
            return Year == other.Year && Month == other.Month;
        }


        public int CompareTo(DateOfMonth other)
        {
            if (this > other)
            {
                return 1;
            }

            if (this < other)
            {
                return -1;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is DateOfMonth && Equals((DateOfMonth)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Year * 397) ^ Month;
            }
        }

        public DateTime GetStartPeriodDate()
        {
            return GetStartMonthDate();
        }

        public DateOfMonth GetNext()
        {
            return new DateOfMonth(GetStartMonthDate().AddMonths(1));
        }

        public DateOfMonth GetPrevious()
        {
            return new DateOfMonth(GetStartMonthDate().AddMonths(-1));
        }

        public override string ToString()
        {
            return $"{Month}-{Year}";
        }

        public DateTime ToDateTime(int day = 1)
        {
            return new DateTime(Year, Month, day);
        }
    }
}