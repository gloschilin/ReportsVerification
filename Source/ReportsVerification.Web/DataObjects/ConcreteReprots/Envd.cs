using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class Envd : Report
    {
        public Envd(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.Envd.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.Envd;
    }
}