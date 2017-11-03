using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Services.Validation.Interfaces
{
    public interface IReportsValidationService
    {
        void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }
}