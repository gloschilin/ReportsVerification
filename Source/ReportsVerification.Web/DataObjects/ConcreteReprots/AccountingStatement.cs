using System;
using System.Xml.Linq;

namespace ReportsVerification.Web.DataObjects.ConcreteReprots
{
    public class AccountingStatement : Report
    {
        public AccountingStatement(XDocument content) : base(content)
        {
        }

        protected override Type XsdReportType()
        {
            return typeof(Xsd.AccountingStatement.Файл);
        }

        public override ReportTypes ReportType => ReportTypes.AccountingStatement;
    }
}