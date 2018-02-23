using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement6Q1Validtor
        : AccountingStatement6Validtor
    {
        public AccountingStatement6Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement6Q2Validtor
        : AccountingStatement6Validtor
    {
        public AccountingStatement6Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement6Q3Validtor
        : AccountingStatement6Validtor
    {
        public AccountingStatement6Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement6Q4Validtor
        : AccountingStatement6Validtor
    {
        public AccountingStatement6Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement6Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement6Validtor;

        protected AccountingStatement6Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            throw new NotImplementedException();
        }
    }
}