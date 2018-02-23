using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement1Q1Validtor : AccountingStatement1Validtor
    {
        public AccountingStatement1Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }


    public class AccountingStatement1Q2Validtor : AccountingStatement1Validtor
    {
        public AccountingStatement1Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement1Q3Validtor : AccountingStatement1Validtor
    {
        public AccountingStatement1Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement1Q4Validtor : AccountingStatement1Validtor
    {
        public AccountingStatement1Q4Validtor(IValidationContext context)
            : base(context)
        {
        }
        
        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement1Validtor 
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement1Validtor;

        protected AccountingStatement1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport, 
            IReadOnlyCollection<Report> reports, 
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.ВнеОбА.ОтлНалАкт.СумОтч.ToDecimal()
                   - xsdReport.Документ.Баланс.Актив.ВнеОбА.ОтлНалАкт.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ПрибУб.ИзмНалАктив.СумОтч.ToDecimal();
        }
    }
}