using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{

    public class AccountingStatement7Q1Validtor
        : AccountingStatement7Validtor
    {
        public AccountingStatement7Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement7Q2Validtor
        : AccountingStatement7Validtor
    {
        public AccountingStatement7Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement7Q3Validtor
        : AccountingStatement7Validtor
    {
        public AccountingStatement7Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement7Q4Validtor
        : AccountingStatement7Validtor
    {
        public AccountingStatement7Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement7Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement7Validtor;


        protected AccountingStatement7Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.СумПрдшв.ToDecimal()
                   == xsdReport.Документ.Баланс.Пассив.СумПрдшв.ToDecimal();
        }
    }

}