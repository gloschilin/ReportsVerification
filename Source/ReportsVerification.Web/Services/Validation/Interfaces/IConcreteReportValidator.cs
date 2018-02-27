using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Services.Validation.Interfaces
{
    public interface IConcreteReportValidator : IReportsValidator
    {
        ReportTypes[] ReportTypesSupport { get; }
    }
}