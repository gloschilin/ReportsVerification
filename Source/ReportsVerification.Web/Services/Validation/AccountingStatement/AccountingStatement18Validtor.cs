using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement18Q1Validtor
        : AccountingStatement18Validtor
    {
        public AccountingStatement18Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement18Q2Validtor
        : AccountingStatement18Validtor
    {
        public AccountingStatement18Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement18Q3Validtor
        : AccountingStatement18Validtor
    {
        public AccountingStatement18Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement18Q4Validtor
        : AccountingStatement18Validtor
    {
        public AccountingStatement18Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement18Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement18Validtor;

        protected AccountingStatement18Validtor(IValidationContext context) : base(context)
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

            return kr.РезКапитал.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.Кап31ДекПред.РезКапитал.ToDecimal();
        }
    }
}