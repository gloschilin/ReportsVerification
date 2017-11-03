using System;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.ReportInfoObjects;
using ReportsVerification.Web.Specifications.Interfaces;

namespace ReportsVerification.Web.Specifications
{
    /// <summary>
    /// Спецификация определяет наличие даты в отчете
    /// </summary>
    public class ReportHasDateSpecidication : ISpecification<ReportInfo>
    {
        public bool IsSpecificatedBy(ReportInfo value)
        {
            return !new[] {ReportTypes.PurchasesBookNds, ReportTypes.SalesBookNds}.Contains(value.Type);
        }
    }
}