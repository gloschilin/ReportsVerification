using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement19Q1Validtor
        : AccountingStatement19Validtor
    {
        public AccountingStatement19Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement19Q2Validtor
        : AccountingStatement19Validtor
    {
        public AccountingStatement19Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement19Q3Validtor
        : AccountingStatement19Validtor
    {
        public AccountingStatement19Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement19Q4Validtor
        : AccountingStatement19Validtor
    {
        public AccountingStatement19Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement19Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement19Validtor;

        protected AccountingStatement19Validtor(IValidationContext context) : base(context)
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