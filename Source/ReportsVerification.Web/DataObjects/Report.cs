using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects
{
    /// <summary>
    /// Отчет
    /// </summary>
    public class Report
    {
        public Report(XDocument content)
        {
            Content = content;
        }

        /// <summary>
        /// Контент отчета
        /// </summary>
        public XDocument Content { get; }
    }
}