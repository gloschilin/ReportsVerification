using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement3Q1Validtor : AccountingStatement3Validtor
    {
        public AccountingStatement3Q1Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement3Q2Validtor : AccountingStatement3Validtor
    {
        public AccountingStatement3Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement3Q3Validtor : AccountingStatement3Validtor
    {
        public AccountingStatement3Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement3Q4Validtor : AccountingStatement3Validtor
    {
        public AccountingStatement3Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement3Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement3Validtor;

        protected AccountingStatement3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Пассив.ДолгосрОбяз.ОтложНалОбяз.СумОтч.ToDecimal()
                   - xsdReport.Документ.Баланс.Пассив.ДолгосрОбяз.ОтложНалОбяз.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ПрибУб.ИзмНалОбяз.СумОтч.ToDecimal();
        }
    }
}