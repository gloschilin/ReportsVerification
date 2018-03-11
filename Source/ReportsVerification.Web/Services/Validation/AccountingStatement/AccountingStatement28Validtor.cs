using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement28Q1Validtor
        : AccountingStatement28Validtor
    {
        public AccountingStatement28Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement28Q2Validtor
        : AccountingStatement28Validtor
    {
        public AccountingStatement28Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement28Q3Validtor
        : AccountingStatement28Validtor
    {
        public AccountingStatement28Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement28Q4Validtor
        : AccountingStatement28Validtor
    {
        public AccountingStatement28Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement28Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement28Validtor;

        protected AccountingStatement28Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.ОбА.ДенежнСр.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ДвижениеДен.ОстКонОтч.СумПред.ToDecimal();
        }
    }
}