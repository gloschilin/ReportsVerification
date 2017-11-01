using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;

namespace ReportsVerification.Web.Extentions
{
    public static class ReportInfoCollectionExtentions
    {
        public static bool ContainsReportInfo(this IEnumerable<ReportInfo> reportInfoCollection, ReportInfo info)
        {
            return reportInfoCollection.Any(e => e.Type == info.Type
                                                 && e.GetStartReportPeriod() == info.GetStartReportPeriod());
        }
    }
}