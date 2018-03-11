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
        public class ValidationResult
        {
            public ValidationResultType ResultType { get; set; }
            public ValidationStepType StepType { get; set; }
            public int Quarter { get; set; }
        }

        public enum ValidationResultType
        {
            Success,
            Error
        }

        private static readonly ConcurrentDictionary<Guid, List<ValidationResult>> ValidationResultContent
            = new ConcurrentDictionary<Guid, List<ValidationResult>>();

        public void Wrong(Guid sessionId, ValidationStepType type, int quarter)
        {
            var result = new ValidationResult
            {
                ResultType = ValidationResultType.Error,
                StepType = type,
                Quarter = quarter
            };
            Add(sessionId, result);
        }

        private static void Add(Guid sessionId, ValidationResult validationResult)
        {
            List<ValidationResult> validationResultCollection;
            if (!ValidationResultContent.TryGetValue(sessionId, 
                out validationResultCollection))
            {
                validationResultCollection = new List<ValidationResult>();
            }
            validationResultCollection.Add(validationResult);
            ValidationResultContent[sessionId] = validationResultCollection;
        }

        public void Success(Guid sessionId, ValidationStepType type)
        {
            var result = new ValidationResult
            {
                ResultType = ValidationResultType.Success,
                StepType = type
            };
            Add(sessionId, result);
        }

        public void Clear(Guid sessionId)
        {
            ValidationResultContent[sessionId] = new List<ValidationResult>();
        }

        public IEnumerable<ValidationResult> GetWrongMessages(Guid sessionId)
        {
            List<ValidationResult> validationResultCollection;
            if (!ValidationResultContent.TryGetValue(sessionId, out validationResultCollection))
            {
                return new List<ValidationResult>();
            }
            var result = validationResultCollection
                .Where(e => e.ResultType == ValidationResultType.Error).ToList();
            return result;
        }

    }
}