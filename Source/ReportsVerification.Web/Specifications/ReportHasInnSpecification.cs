using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Specifications.Interfaces;

namespace ReportsVerification.Web.Specifications
{
    public class ReportHasInnSpecification : ISpecification<ReportInfo>
    {
        public bool IsSpecificatedBy(ReportInfo value)
        {
            return !new[] { ReportTypes.PurchasesBookNds, ReportTypes.SalesBookNds }.Contains(value.Type);
        }
    }
}