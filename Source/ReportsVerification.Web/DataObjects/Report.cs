using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
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

        public static bool TryParse(Type xsdReportType, XDocument reportContent, out IXsdReport xsdReport)
        {
            xsdReport = null;

            if (reportContent == null)
            {
                return false;
            }

            try
            {
                var serializer = new XmlSerializer(xsdReportType);

                using (var reader = new StringReader(reportContent.ToString()))
                {
                    xsdReport = serializer.Deserialize(reader) as IXsdReport;
                }
                return true;

            }
            catch
            {
                return false;
            }
        }

        private IXsdReport _xsdReport;

        public IXsdReport XsdReport
        {
            get
            {
                if (_xsdReport != null)
                {
                    return _xsdReport;
                }

                if (TryParse(XsdReportType(), Content, out _xsdReport))
                {
                    return _xsdReport;
                }

                throw new ApplicationException(
                   "Созданный тип отчета не является реализацией интерфейса IXsdReport");
            }
        }

        /// <summary>
        /// Получить тип соответствующего отчета XSD
        /// </summary>
        /// <returns></returns>
        protected abstract Type XsdReportType();

        public abstract ReportTypes ReportType { get; }

        public ReportInfo GetReportInfo()
        {
            if (Info == null)
            {
                throw new ApplicationException("Информация о отчете не установлена");
            }

            return Info;
        }

        public XDocument GetContent()
        {
            return Content;
        }

        private ReportInfo Info { get; set; }

        public void SetInfo(ReportInfo reportInfo)
        {
            Info = reportInfo;
        }
    }
}