using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ReportsVerification.Web.Utills.Converters
{
    /// <summary>
    /// Установка нужного формата даты
    /// </summary>
    public class Json2DateFormatConverter : DateTimeConverterBase
    {
        private readonly string _dateFormat;

        /// <summary>
        /// Максимальное значение даты, которое поддерживаем на фронте
        /// </summary>
        private readonly DateTime _maxDateJsonValue = new DateTime(2100,01,01);

        public Json2DateFormatConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, 
            JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (DateTime) value;
            if (date > _maxDateJsonValue)
            {
                date = _maxDateJsonValue;
            }
            writer.WriteValue(date.ToString(_dateFormat));
        }
    }
}