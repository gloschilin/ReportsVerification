using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class CalculationAdvancePayment : Report
    {
        public CalculationAdvancePayment(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.CalculationAdvancePayment.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.CalculationAdvancePayment;
    }
}