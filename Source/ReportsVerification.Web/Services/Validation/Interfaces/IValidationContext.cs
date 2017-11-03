using System;
using System.Collections.Generic;

namespace ReportsVerification.Web.Services.Validation.Interfaces
{
    public interface IValidationContext
    {
        void Wrong(Guid sessionId, ValidationStepType type);
        void Success(Guid sessionId, ValidationStepType type);
        void Clear(Guid sessionId);
        IEnumerable<ValidationStepType> GetWrongMessages(Guid sessionId);
    }
}