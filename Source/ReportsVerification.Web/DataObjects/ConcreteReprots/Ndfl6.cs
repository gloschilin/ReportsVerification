using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class Ndfl6 : Report
    {
        public Ndfl6(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.Ndfl6.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.Ndfl6;
    }
}