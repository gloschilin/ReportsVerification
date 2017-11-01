using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects.Xsd.Fss4;

namespace ReportsVerification.Web.DataObjects.Dates
{
    /// <summary>
    /// Получение даты из указанного периода отчета
    /// </summary>
    public static class DateOfQuarterExtentions
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
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static DateOfQuarter ReadFromPeriod(this DateOfQuarter date, int year, int period)
        {
            int quarter;
            if (!LinkPeriodToQuarter.Value.TryGetValue(period, out quarter))
            {
                throw new ApplicationException("Указанный период не обработан");
            }
            return new DateOfQuarter(year, quarter);
        }

        /// <summary>
        /// Получение значения месяца из узла отчета 4ФСС
        /// </summary>
        /// <param name="date"></param>
        /// <param name="titleTypeNode"></param>
        /// <returns></returns>
        public static DateOfQuarter ReadFssDate(this DateOfQuarter date, TitleType titleTypeNode)
        {
            var year = int.Parse(titleTypeNode.YEAR_NUM);
            var quarter = int.Parse(titleTypeNode.QUART_NUM);
            return new DateOfQuarter(year, quarter);
        }
    }
}