using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class Usn : Report
    {
        public Usn(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.Usn.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.Usn;
    }
}