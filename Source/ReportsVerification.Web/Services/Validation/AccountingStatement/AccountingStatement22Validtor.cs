using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement22Q1Validtor
        : AccountingStatement22Validtor
    {
        public AccountingStatement22Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement22Q2Validtor
        : AccountingStatement22Validtor
    {
        public AccountingStatement22Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement22Q3Validtor
        : AccountingStatement22Validtor
    {
        public AccountingStatement22Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement22Q4Validtor
        : AccountingStatement22Validtor
    {
        public AccountingStatement22Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement22Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement22Validtor;

        protected AccountingStatement22Validtor(IValidationContext context) : base(context)
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

            return kr.СумОтч.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ОтчетГод.Кап31дек.Итог.ToDecimal();
        }
    }
}