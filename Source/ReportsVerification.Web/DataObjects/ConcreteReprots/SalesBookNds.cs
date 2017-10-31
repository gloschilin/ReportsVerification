using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class SalesBookNds : Report
    {
        public SalesBookNds(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof (Xsd.SalesBookNds.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.SalesBookNds;
    }
}