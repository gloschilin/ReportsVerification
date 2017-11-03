using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation
{
    public class ReportsValidationService: IReportsValidationService
    {
        private readonly IEnumerable<IReportsConcreteValidationService> _services;

        public ReportsValidationService(IEnumerable<IReportsConcreteValidationService> services)
        {
            _services = services;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            foreach (var service in _services)
            {
                service.Validate(reports, sessionInfo);
            }
        }
    }
}