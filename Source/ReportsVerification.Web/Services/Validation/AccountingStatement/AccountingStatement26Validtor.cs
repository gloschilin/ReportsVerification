using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement26Q1Validtor
        : AccountingStatement26Validtor
    {
        public AccountingStatement26Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement26Q2Validtor
        : AccountingStatement26Validtor
    {
        public AccountingStatement26Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement26Q3Validtor
        : AccountingStatement26Validtor
    {
        public AccountingStatement26Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement26Q4Validtor
        : AccountingStatement26Validtor
    {
        public AccountingStatement26Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement26Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement26Validtor;

        protected AccountingStatement26Validtor(IValidationContext context) : base(context)
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

            return kr.ПереоцВнеОбА.СумПрдщ.ToDecimal()
                   + kr.ДобКапитал.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ПредГод.Кап31дек.ДобКапитал.ToDecimal();
        }
    }
}