using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement9Q1Validtor
        : AccountingStatement9Validtor
    {
        public AccountingStatement9Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement9Q2Validtor
        : AccountingStatement9Validtor
    {
        public AccountingStatement9Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement9Q3Validtor
        : AccountingStatement9Validtor
    {
        public AccountingStatement9Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement9Q4Validtor
        : AccountingStatement9Validtor
    {
        public AccountingStatement9Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement9Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement9Validtor;

        protected AccountingStatement9Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.СумОтч.ToDecimal()
                   == xsdReport.Документ.Баланс.Пассив.СумОтч.ToDecimal();
        }
    }
}