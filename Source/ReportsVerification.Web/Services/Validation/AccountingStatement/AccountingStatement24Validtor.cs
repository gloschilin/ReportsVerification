using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement24Q1Validtor
        : AccountingStatement24Validtor
    {
        public AccountingStatement24Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement24Q2Validtor
        : AccountingStatement24Validtor
    {
        public AccountingStatement24Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement24Q3Validtor
        : AccountingStatement24Validtor
    {
        public AccountingStatement24Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement24Q4Validtor
        : AccountingStatement24Validtor
    {
        public AccountingStatement24Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement24Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement24Validtor;

        protected AccountingStatement24Validtor(IValidationContext context) : base(context)
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

            return kr.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.Кап31ДекПред.Итог.ToDecimal();
        }
    }
}