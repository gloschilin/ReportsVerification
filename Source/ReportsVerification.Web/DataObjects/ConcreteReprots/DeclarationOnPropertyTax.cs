using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class DeclarationOnPropertyTax : Report
    {
        public DeclarationOnPropertyTax(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.DeclarationOnPropertyTax.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.DeclarationOnPropertyTax;
    }
}