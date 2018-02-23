using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement27Q1Validtor
        : AccountingStatement27Validtor
    {
        public AccountingStatement27Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement27Q2Validtor
        : AccountingStatement27Validtor
    {
        public AccountingStatement27Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement27Q3Validtor
        : AccountingStatement27Validtor
    {
        public AccountingStatement27Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement27Q4Validtor
        : AccountingStatement27Validtor
    {
        public AccountingStatement27Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement27Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement27Validtor;

        protected AccountingStatement27Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.Баланс.Актив.ОбА.ДенежнСр.СумОтч.ToDecimal()
                   == xsdReport.Документ.ДвижениеДен.ОстКонОтч.СумОтч.ToDecimal();
        }
    }
}