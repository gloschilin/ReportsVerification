using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation
{
    public class PrimaryReportsValidator : IPrimaryReportsValidator
    {
        private readonly IEnumerable<IConcretePrimaryReportValidator> _services;

        public PrimaryReportsValidator(IEnumerable<IConcretePrimaryReportValidator> services)
        {
            _services = services;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo,
            ValidationType validationType)
        {
            foreach (var service in _services)
            {
                service.Validate(reports, sessionInfo);
            }
        }
    }
}