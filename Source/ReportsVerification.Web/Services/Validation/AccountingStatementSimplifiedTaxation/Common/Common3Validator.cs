using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatementSimplifiedTaxation;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatementSimplifiedTaxation.Common
{
    public abstract class Common3Validator
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.CurencyBalance3Validator;

        protected Common3Validator(IValidationContext context)
            : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports, SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.СумОтч
                   == xsdReport.Документ.Баланс.Пассив.СумОтч;
        }
    }
}