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

        public static DateOfMonth ByFssDate(int year, string fss4Quarter)
        {
            int month;

            switch (fss4Quarter)
            {
                case "3":
                case "6":
                case "9":
                case "12":
                    month = int.Parse(fss4Quarter) - 2;
                    break;
                default:
                    throw new ApplicationException($"Необработанное значение квартала для отчета 4 ФСС = {fss4Quarter}");
            }

            return new DateOfMonth(year, month);
        }
    }
}