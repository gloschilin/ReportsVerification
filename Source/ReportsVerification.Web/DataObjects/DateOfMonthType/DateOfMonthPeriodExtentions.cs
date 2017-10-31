using System;
using System.Collections.Generic;

namespace ReportsVerification.Web.DataObjects.DateOfMonthType
{
    /// <summary>
    /// Получение даты из указанного периода отчета
    /// </summary>
    public partial class DateOfMonth
    {
        private static readonly Lazy<Dictionary<int, int>> LinkPeriodToQuarter 
            = new Lazy<Dictionary<int, int>>(GetLinks);

        private static Dictionary<int, int> GetLinks()
        {
            return new Dictionary<int, int>
            {
                { 21, 1 },
                { 17, 2 },
                { 22, 2 },
                { 31, 2 },
                { 18, 3 },
                { 23, 3 },
                { 33, 3 },
                { 24, 4 },
                { 34, 4 }
            };
        }

        /// <summary>
        /// Получение даты из указанного периода отчета
        /// </summary>
        /// <param name="year"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static DateOfMonth ReadFromPeriod(int year, int period)
        {
            int quarter;
            if (!LinkPeriodToQuarter.Value.TryGetValue(period, out quarter))
            {
                throw new ApplicationException("Указанный период не обработан");
            }

            var month = GetMonthFromQuarter(quarter);
            return new DateOfMonth(year, month);
        }
    }
}