using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Common
{
    public abstract class CommonConcreteValidationService : IReportsConcreteValidationService
    {
        private readonly IValidationHandler _handler;
        protected abstract ValidationStepType Type { get; }

        protected CommonConcreteValidationService(IValidationHandler handler)
        {
            _handler = handler;
        }

        public void Validate(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            if (IsValid(reports, sessionInfo))
            {
                _handler.Success(Type);
            }
            else
            {
                _handler.Wrong(Type);
            }
        }

        protected abstract bool IsValid(IReadOnlyCollection<Report> reports, SessionInfo sessionInfo);
    }
}