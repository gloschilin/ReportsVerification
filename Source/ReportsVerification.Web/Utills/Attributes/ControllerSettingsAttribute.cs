using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ReportsVerification.Web.Utills.Converters;

namespace ReportsVerification.Web.Utills.Attributes
{
    /// <summary>
    /// Атрибут настройки контроллера
    /// </summary>
    public class ControllerSettingsAttribute : Attribute, IControllerConfiguration
    {
        private readonly string _dateTimeFormat;
        private readonly bool _allowCamelCase;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimeFormat"></param>
        /// <param name="allowCamelCase"></param>
        public ControllerSettingsAttribute(string dateTimeFormat = "dd.MM.yyyy",
            bool allowCamelCase = false)
        {
            _dateTimeFormat = dateTimeFormat;
            _allowCamelCase = allowCamelCase;
        }

        public void Initialize(HttpControllerSettings controllerSettings,
            HttpControllerDescriptor controllerDescriptor)
        {
            var formatter = new JsonMediaTypeFormatter();

            if (_allowCamelCase)
            {
                formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            else
            {
                formatter.SerializerSettings.ContractResolver = new JsonContractResolver(new JsonMediaTypeFormatter());
            }

            var dateTimeConverter = new Json2DateFormatConverter(_dateTimeFormat);
            var baseConverter = formatter.SerializerSettings.Converters.FirstOrDefault(e => e is DateTimeConverterBase);
            if (baseConverter != null)
            {
                formatter.SerializerSettings.Converters.Remove(baseConverter);
            }
            formatter.SerializerSettings.Converters.Add(dateTimeConverter);
            formatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            formatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            controllerSettings.Formatters.Clear();
            controllerSettings.Formatters.Add(formatter);
        }
    }

    
}