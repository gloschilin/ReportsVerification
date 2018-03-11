using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public abstract class AccountingStatement4Validtor
        : CommonValidator
    {
        protected AccountingStatement4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Пассив.ДолгосрОбяз.ОтложНалОбяз.СумПрдщ.ToDecimal()
                   - xsdReport.Документ.Баланс.Пассив.ДолгосрОбяз.ОтложНалОбяз.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.ПрибУб.ИзмНалОбяз.СумПред.ToDecimal();
        }

        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement4Validtor;
    }

    [ValidatorQuarter(1)]
    public class AccountingStatement4Q1Validtor: AccountingStatement4Validtor
    {
        public AccountingStatement4Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement4Q2Validtor : AccountingStatement4Validtor
    {
        public AccountingStatement4Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement4Q3Validtor : AccountingStatement4Validtor
    {
        public AccountingStatement4Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement4Q4Validtor : AccountingStatement4Validtor
    {
        public AccountingStatement4Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }
}