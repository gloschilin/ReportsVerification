using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class DeclarationOnIncomeTax : Report
    {
        public DeclarationOnIncomeTax(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.DeclarationOnIncomeTax.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.DeclarationOnIncomeTax;
    }
}