using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement29Q1Validtor
        : AccountingStatement29Validtor
    {
        public AccountingStatement29Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement29Q2Validtor
        : AccountingStatement29Validtor
    {
        public AccountingStatement29Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement29Q3Validtor
        : AccountingStatement29Validtor
    {
        public AccountingStatement29Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement29Q4Validtor
        : AccountingStatement29Validtor
    {
        public AccountingStatement29Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement29Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement29Validtor;

        protected AccountingStatement29Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.ОбА.ДенежнСр.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.ДвижениеДен.ОстНачОтч.СумПред.ToDecimal();
        }
    }
}