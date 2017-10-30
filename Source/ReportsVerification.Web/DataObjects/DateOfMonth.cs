using System;

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

        public static DateOfMonth FromPeriod(int year, string period)
        {
            int month;

            switch (period)
            {
                case "21":
                    month = 1;
                    break;
                case "31":
                    month = 4;
                    break;
                case "33":
                    month = 7;
                    break;
                case "34":
                    month = 10;
                    break;
                default:
                    throw new ApplicationException("Указанный строковой период не определен");

            }

            return new DateOfMonth(year, month);
        }
    }
}