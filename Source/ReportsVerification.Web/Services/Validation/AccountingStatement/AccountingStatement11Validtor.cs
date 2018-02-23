using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement11Q1Validtor :
        AccountingStatement11Validtor
    {
        public AccountingStatement11Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement11Q2Validtor :
        AccountingStatement11Validtor
    {
        public AccountingStatement11Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement11Q3Validtor :
        AccountingStatement11Validtor
    {
        public AccountingStatement11Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement11Q4Validtor :
        AccountingStatement11Validtor
    {
        public AccountingStatement11Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement11Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement11Validtor;

        protected AccountingStatement11Validtor(IValidationContext context) : base(context)
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

            return kr.УставКапитал.СумПрдщ.ToDecimal() ==
                   xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ПредГод.Кап31дек.УстКапитал.ToDecimal();
        }
    }
}