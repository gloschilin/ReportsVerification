using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class PurchasesBookNds: Report
    {
        public PurchasesBookNds(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof (Xsd.PurchasesBookNds.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.PurchasesBookNds;
    }
}