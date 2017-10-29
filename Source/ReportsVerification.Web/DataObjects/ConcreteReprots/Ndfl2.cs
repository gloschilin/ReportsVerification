using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class Ndfl2 : Report
    {
        public Ndfl2(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof (Xsd.Ndfl2.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.Ndfl2;
    }
}