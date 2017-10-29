using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class Nds : Report
    {
        public Nds(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.Nds.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.Nds;
    }
}