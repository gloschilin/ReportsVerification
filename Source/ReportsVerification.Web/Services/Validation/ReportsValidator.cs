using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation
{
    public enum ValidationType
    {
        Primary,
        Secondary
    }

    public class ReportsValidator: IReportsValidator
    {
        private readonly IEnumerable<IConcreteReportValidator> _services;
        private readonly IPrimaryReportsValidator _primaryReportsValidator;
        private readonly IValidationContext _validationContext;
        private readonly IRevisionFilerService _revisionFilerService;

        public ReportsValidator(IEnumerable<IConcreteReportValidator> services,
            IPrimaryReportsValidator primaryReportsValidator,
            IValidationContext validationContext,
            IRevisionFilerService revisionFilerService)
        {
            _services = services;
            _primaryReportsValidator = primaryReportsValidator;
            _validationContext = validationContext;
            _revisionFilerService = revisionFilerService;
        }

        public void Validate(IReadOnlyCollection<Report> reports, 
            SessionInfo sessionInfo,
            ValidationType validationType = ValidationType.Primary)
        {
            reports = _revisionFilerService.GetActualReports(reports).ToList();
            _validationContext.Clear(sessionInfo.Id);
            _primaryReportsValidator.Validate(reports, sessionInfo);
            var wrongReports = _validationContext.GetWrongMessages(sessionInfo.Id);
            if (wrongReports.Any() || validationType == ValidationType.Primary)
            {
                return;
            }

            var servicesLen = 0;
            foreach (var validator in _services)
            {
                if (validator.ReportTypesSupport.Any() 
                    && validator.ReportTypesSupport.All(e => reports.Any(r => r.ReportType == e)))
                {
                    servicesLen++;
                }
            }

            if (servicesLen == 0)
            {
                //_validationContext.Wrong(sessionInfo.Id, 
                //    ValidationStepType.EmptyServicesValidator, 4);
                return;
            }

            foreach (var service in _services)
            {
                service.Validate(reports, sessionInfo);
            }
        }
    }
}