using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class SzvM : Report
    {
        public SzvM(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.CalculationContributions.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.SzvM;
    }
}