using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatementSimplifiedTaxation;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common
{
    public abstract class Common1Validator
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.CurencyBalance1Validator;

        protected Common1Validator(IValidationContext context) 
            : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport, 
            IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.СумПрдшв
                   == xsdReport.Документ.Баланс.Пассив.СумПрдшв;
        }
    }
}