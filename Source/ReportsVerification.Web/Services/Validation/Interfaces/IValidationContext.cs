using System;
using System.Collections.Generic;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Services.Validation.Interfaces
{
    public interface IValidationContext
    {
        void Wrong(Guid sessionId, ValidationStepType type, int quarter);
        void Success(Guid sessionId, ValidationStepType type);
        void Clear(Guid sessionId);
        IEnumerable<HttpValidationContext.ValidationResult> GetWrongMessages(Guid sessionId);
    }
}