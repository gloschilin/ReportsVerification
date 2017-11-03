using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation
{
    public class ReportsValidator: IReportsValidator
    {
        private readonly IEnumerable<IConcreteReportValidator> _services;
        private readonly IPrimaryReportsValidator _primaryReportsValidator;
        private readonly IValidationContext _validationContext;

        public ReportsValidator(IEnumerable<IConcreteReportValidator> services,
            IPrimaryReportsValidator primaryReportsValidator,
            IValidationContext validationContext)
        {
            _services = services;
            _primaryReportsValidator = primaryReportsValidator;
            _validationContext = validationContext;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            _primaryReportsValidator.Validate(reports, sessionInfo);
            var wrongReports = _validationContext.GetWrongMessages(sessionInfo.Id);
            if (wrongReports.Any())
            {
                return;
            }

            foreach (var service in _services)
            {
                service.Validate(reports, sessionInfo);
            }
        }
    }
}