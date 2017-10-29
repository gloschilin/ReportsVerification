using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class CalculationContributions : Report
    {
        public CalculationContributions(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.CalculationContributions.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.CalculationContributions;
    }
}