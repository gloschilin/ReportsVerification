using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement10Q1Validtor 
    : AccountingStatement10Validtor
    {
        public AccountingStatement10Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement10Q2Validtor
        : AccountingStatement10Validtor
    {
        public AccountingStatement10Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement10Q3Validtor
        : AccountingStatement10Validtor
    {
        public AccountingStatement10Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement10Q4Validtor
        : AccountingStatement10Validtor
    {
        public AccountingStatement10Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement10Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement10Validtor;

        protected AccountingStatement10Validtor(IValidationContext context) : base(context)
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

            return kr.УставКапитал.СумОтч.ToDecimal() ==
                   xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ОтчетГод.Кап31дек.УстКапитал.ToDecimal();
        }
    }
}