using System.Collections.Generic;

namespace ReportsVerification.Web.Services.Validation.Interfaces
{
    public interface IValidationHandler
    {
        void Wrong(ValidationStepType type);
        void Success(ValidationStepType type);
        IEnumerable<ValidationStepType> GetWrongMessages();
    }
}