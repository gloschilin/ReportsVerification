using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement15Q1Validtor
        : AccountingStatement15Validtor
    {
        public AccountingStatement15Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement15Q2Validtor
        : AccountingStatement15Validtor
    {
        public AccountingStatement15Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement15Q3Validtor
        : AccountingStatement15Validtor
    {
        public AccountingStatement15Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement15Q4Validtor
        : AccountingStatement15Validtor
    {
        public AccountingStatement15Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement15Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement15Validtor;

        protected AccountingStatement15Validtor(IValidationContext context) : base(context)
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

            return kr.СобствАкции.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.Кап31ДекПред.СобВыкупАкц.ToDecimal();
        }
    }
}