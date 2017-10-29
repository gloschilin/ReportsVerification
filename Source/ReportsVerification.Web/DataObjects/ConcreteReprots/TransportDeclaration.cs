using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class TransportDeclaration : Report
    {
        public TransportDeclaration(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.TransportDeclaration.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.TransportDeclaration;
    }
}