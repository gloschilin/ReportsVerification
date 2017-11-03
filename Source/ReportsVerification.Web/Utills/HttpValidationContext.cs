using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Utills
{
    public class HttpValidationContext : IValidationContext
    {
        private class ValidationResult
        {
            public ValidationResultType ResultType { get; set; }
            public ValidationStepType StepType { get; set; }
        }

        private enum ValidationResultType
        {
            Success,
            Error
        }

        private static readonly ConcurrentDictionary<Guid, List<ValidationResult>> ValidationResultContent
            = new ConcurrentDictionary<Guid, List<ValidationResult>>();

        public void Wrong(Guid sessionId, ValidationStepType type)
        {
            var result = new ValidationResult { ResultType = ValidationResultType.Error, StepType = type };
            Add(sessionId, result);
        }

        private static void Add(Guid sessionId, ValidationResult validationResult)
        {
            List<ValidationResult> validationResultCollection;
            if (!ValidationResultContent.TryGetValue(sessionId, out validationResultCollection))
            {
                validationResultCollection = new List<ValidationResult>();
            }
            validationResultCollection.Add(validationResult);
            ValidationResultContent[sessionId] = validationResultCollection;
        }

        public void Success(Guid sessionId, ValidationStepType type)
        {
            var result = new ValidationResult { ResultType = ValidationResultType.Success, StepType = type };
            Add(sessionId, result);
        }

        public void Clear(Guid sessionId)
        {
            ValidationResultContent[sessionId] = new List<ValidationResult>();
        }

        public IEnumerable<ValidationStepType> GetWrongMessages(Guid sessionId)
        {
            List<ValidationResult> validationResultCollection;
            if (!ValidationResultContent.TryGetValue(sessionId, out validationResultCollection))
            {
                return new List<ValidationStepType>();
            }

            return validationResultCollection.Where(e => e.ResultType == ValidationResultType.Error)
                .Select(e => e.StepType).ToList();
        }

    }
}