using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;

namespace ReportsVerification.Web.Services.Validation
{
    public interface IReportsValidationService
    {
        void Validate(IEnumerable<Report> reports, SessionInfo sessionInfo);
    }
}