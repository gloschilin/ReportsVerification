using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Common
{
    public abstract class CommonConcreteReportValidator : IConcreteReportValidator
    {
        private readonly IValidationContext _context;
        protected abstract ValidationStepType Type { get; }

        protected CommonConcreteReportValidator(IValidationContext context)
        {
            _context = context;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (IsValid(reports, sessionInfo))
            {
                _context.Success(sessionInfo.Id, Type);
            }
            else
            {
                _context.Wrong(sessionInfo.Id, Type);
            }
        }

        protected abstract bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }
}