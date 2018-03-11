using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement12Q1Validtor
        : AccountingStatement12Validtor
    {
        public AccountingStatement12Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement12Q2Validtor
        : AccountingStatement12Validtor
    {
        public AccountingStatement12Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement12Q3Validtor
        : AccountingStatement12Validtor
    {
        public AccountingStatement12Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement12Q4Validtor
        : AccountingStatement12Validtor
    {
        public AccountingStatement12Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement12Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement12Validtor;

        protected AccountingStatement12Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            var kr = xsdReport.Документ.Баланс.Пассив.Item as ФайлДокументБалансПассивКапРез;

            if (kr == null)
            {
                return true;
            }

            return kr.УставКапитал.СумПрдшв.ToDecimal() ==
                   xsdReport.Документ.ОтчетИзмКап.ДвиженКап.Кап31ДекПред.УстКапитал.ToDecimal();
        }
    }
}