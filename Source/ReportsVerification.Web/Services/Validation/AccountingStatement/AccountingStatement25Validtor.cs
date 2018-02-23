using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement25Q1Validtor
    : AccountingStatement25Validtor
    {
        public AccountingStatement25Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement25Q2Validtor
        : AccountingStatement25Validtor
    {
        public AccountingStatement25Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement25Q3Validtor
        : AccountingStatement25Validtor
    {
        public AccountingStatement25Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement25Q4Validtor
        : AccountingStatement25Validtor
    {
        public AccountingStatement25Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 5;
    }

    public abstract class AccountingStatement25Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement25Validtor;

        protected AccountingStatement25Validtor(IValidationContext context) : base(context)
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

            return kr.ПереоцВнеОбА.СумОтч.ToDecimal() 
                   + kr.ДобКапитал.СумОтч.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ОтчетГод.Кап31дек.ДобКапитал.ToDecimal();
        }
    }
}