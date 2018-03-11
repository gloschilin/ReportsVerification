using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement2Q1Validtor : AccountingStatement2Validtor
    {
        public AccountingStatement2Q1Validtor(IValidationContext context)
            : base(context)
        {
        }
        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement2Q2Validtor : AccountingStatement2Validtor
    {
        public AccountingStatement2Q2Validtor(IValidationContext context)
            : base(context)
        {
        }
        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement2Q3Validtor : AccountingStatement2Validtor
    {
        public AccountingStatement2Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement2Q4Validtor : AccountingStatement2Validtor
    {
        public AccountingStatement2Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }


    public abstract class AccountingStatement2Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement2Validtor;

        protected AccountingStatement2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.ВнеОбА.ОтлНалАкт.СумПрдщ.ToDecimal()
                   - xsdReport.Документ.Баланс.Актив.ВнеОбА.ОтлНалАкт.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.ПрибУб.ИзмНалАктив.СумПред.ToDecimal();
        }
    }
}