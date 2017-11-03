using System;
using System.Collections.Generic;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Utills
{
    public class HttpValidationHandler : IValidationHandler
    {
        public void Wrong(ValidationStepType type)
        {
            throw new NotImplementedException();
        }

        public void Success(ValidationStepType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationStepType> GetWrongMessages()
        {
            throw new NotImplementedException();
        }
    }
}