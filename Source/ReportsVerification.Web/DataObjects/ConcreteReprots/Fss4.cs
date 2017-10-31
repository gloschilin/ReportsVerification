using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class Fss4: Report
    {
        public Fss4(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof (Xsd.Fss4.F4ReportType);
        }

        public override ReportTypes ReportType => ReportTypes.Fss4;
    }
}