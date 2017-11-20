using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Utills;

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
            bool isValid;

            try
            {
                isValid = IsValid(reports, sessionInfo);
            }
            catch (Exception ex)
            {
                AppLog.Instance().Error($"Ошибка при валидации {GetType().Name}, " +
                                        $"userId = {sessionInfo.ActionUserId}, " +
                                        $"sessionId={sessionInfo.Id}", ex);
                isValid = true;
            }
            
            if (isValid)
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