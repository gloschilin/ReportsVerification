using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class DeclarationOnLandTax : Report
    {
        public DeclarationOnLandTax(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.DeclarationOnLandTax.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.DeclarationOnLandTax;
    }
}