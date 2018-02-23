using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement8Q1Validtor
        : AccountingStatement8Validtor
    {
        public AccountingStatement8Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement8Q2Validtor
        : AccountingStatement8Validtor
    {
        public AccountingStatement8Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement8Q3Validtor
        : AccountingStatement8Validtor
    {
        public AccountingStatement8Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement8Q4Validtor
        : AccountingStatement8Validtor
    {
        public AccountingStatement8Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement8Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement8Validtor;

        protected AccountingStatement8Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.Баланс.Пассив.СумПрдщ.ToDecimal();
        }
    }
}