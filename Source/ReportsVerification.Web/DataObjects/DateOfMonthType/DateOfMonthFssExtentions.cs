using ReportsVerification.Web.DataObjects.Xsd.Fss4;

namespace ReportsVerification.Web.DataObjects.DateOfMonthType
{
    /// <summary>
    /// Получение значения месяца из узла отчета 4ФСС
    /// </summary>
    public partial class DateOfMonth
    {
        /// <summary>
        /// Получение значения месяца из узла отчета 4ФСС
        /// </summary>
        /// <param name="titleTypeNode"></param>
        /// <returns></returns>
        public static DateOfMonth ReadFssDate(TitleType titleTypeNode)
        {
            var year = int.Parse(titleTypeNode.YEAR_NUM);
            var quarter = int.Parse(titleTypeNode.QUART_NUM);
            var month = GetMonthFromQuarter(quarter);
            return new DateOfMonth(year, month);
        }
    }
}