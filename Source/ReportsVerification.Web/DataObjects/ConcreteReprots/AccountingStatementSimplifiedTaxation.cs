using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class AccountingStatementSimplifiedTaxation : Report
    {
        public AccountingStatementSimplifiedTaxation(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.AccountingStatementSimplifiedTaxation.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.AccountingStatementSimplifiedTaxation;
    }
}