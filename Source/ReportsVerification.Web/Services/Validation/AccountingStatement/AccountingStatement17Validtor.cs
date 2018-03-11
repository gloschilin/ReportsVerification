using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement17Q1Validtor
        : AccountingStatement17Validtor
    {
        public AccountingStatement17Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement17Q2Validtor
        : AccountingStatement17Validtor
    {
        public AccountingStatement17Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement17Q3Validtor
        : AccountingStatement17Validtor
    {
        public AccountingStatement17Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement17Q4Validtor
        : AccountingStatement17Validtor
    {
        public AccountingStatement17Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement17Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement17Validtor;

        protected AccountingStatement17Validtor(IValidationContext context) : base(context)
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

            return kr.РезКапитал.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ПредГод.Кап31дек.РезКапитал.ToDecimal();
        }
    }
}