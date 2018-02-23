using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement14Q1Validtor
        : AccountingStatement14Validtor
    {
        public AccountingStatement14Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement14Q2Validtor
        : AccountingStatement14Validtor
    {
        public AccountingStatement14Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement14Q3Validtor
        : AccountingStatement14Validtor
    {
        public AccountingStatement14Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement14Q4Validtor
        : AccountingStatement14Validtor
    {
        public AccountingStatement14Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement14Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement14Validtor;

        protected AccountingStatement14Validtor(IValidationContext context) : base(context)
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

            return kr.СобствАкции.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ПредГод.Кап31дек.СобВыкупАкц.ToDecimal();
        }
    }
}