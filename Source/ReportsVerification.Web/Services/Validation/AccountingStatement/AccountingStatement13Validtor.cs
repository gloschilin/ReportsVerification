using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement13Q1Validtor
        : AccountingStatement13Validtor
    {
        public AccountingStatement13Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement13Q2Validtor
        : AccountingStatement13Validtor
    {
        public AccountingStatement13Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement13Q3Validtor
        : AccountingStatement13Validtor
    {
        public AccountingStatement13Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement13Q4Validtor
        : AccountingStatement13Validtor
    {
        public AccountingStatement13Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement13Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type =>
            ValidationStepType.AccountingStatement13Validtor;

        protected AccountingStatement13Validtor(IValidationContext context) : base(context)
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

            return kr.СобствАкции.СумОтч.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ОтчетГод.Кап31дек.СобВыкупАкц.ToDecimal();
        }
    }
}