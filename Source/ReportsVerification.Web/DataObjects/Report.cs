using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using ReportsVerification.Web.Builders.Interfaces;
using ReportsVerification.Web.DataObjects.Interfaces;

namespace ReportsVerification.Web.DataObjects
{
    /// <summary>
    /// Отчет
    /// </summary>
    public abstract class Report
    {
        protected Report(XDocument content)
        {
            Content = content;
        }

        /// <summary>
        /// Контент отчета
        /// </summary>
        private XDocument Content { get; }

        private IXsdReport _xsdReport;

        public IXsdReport XsdReport
        {
            get
            {
                if (_xsdReport != null)
                {
                    return _xsdReport;
                }

                var serializer = new XmlSerializer(XsdReportType());
                var rdr = new StringReader(Content.ToString());
                _xsdReport = serializer.Deserialize(rdr) as IXsdReport;

                if (_xsdReport == null)
                {
                    throw new ApplicationException(
                        "Созданный тип отчета не является реализацией интерфейса IXsdReport");
                }

                return _xsdReport;
            }
        }

        /// <summary>
        /// Получить тип соответствующего отчета XSD
        /// </summary>
        /// <returns></returns>
        protected abstract Type XsdReportType();

        public abstract ReportTypes ReportType { get; }

        public ReportInfo GetReportInfo(IReportInfoBuilder reportReportInfoBuilder)
        {
            ReportInfo reportInfo;
            if (reportReportInfoBuilder.TryGetInfo(Content, out reportInfo))
            {
                return reportInfo;
            }

            throw new ApplicationException("Неизвестный тип обрабатываемого отчета");
        }
    }
}