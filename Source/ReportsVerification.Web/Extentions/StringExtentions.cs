using System;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Extentions
{
    public static class StringExtentions
    {
        public static decimal ToDecimal(this string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch (Exception ex)
            {
                AppLog.Instance().Error($"Неудалось преобразовать значение {value} в тип decimal", ex);
                throw;
            }
        }

        public static int ToInt(this string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (Exception ex)
            {
                AppLog.Instance().Error($"Неудалось преобразовать значение {value} в тип int", ex);
                throw;
            }
        }
    }
}