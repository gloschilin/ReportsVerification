using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

namespace ReportsVerification.Web.Extentions
{
    public static class ReportInfoCollectionExtentions
    {
        public static bool ContainsReportInfo(this IEnumerable<ReportInfo> reportInfoCollection, ReportInfo info)
        {
            var type2 = info.Type == ReportTypes.AccountingStatementSimplifiedTaxation
                ? ReportTypes.AccountingStatement
                : info.Type;

            return reportInfoCollection.Any(e =>
            {
                var type1 = e.Type == ReportTypes.AccountingStatementSimplifiedTaxation
                    ? ReportTypes.AccountingStatement
                    : e.Type;

                return type1 == type2
                       && e.GetStartReportPeriod() == info.GetStartReportPeriod();
            });
        }
    }
}