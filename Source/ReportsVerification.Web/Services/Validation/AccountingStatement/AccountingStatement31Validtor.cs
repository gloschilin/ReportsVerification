using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement31Q1Validtor
        : AccountingStatement31Validtor
    {
        public AccountingStatement31Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement31Q2Validtor
        : AccountingStatement31Validtor
    {
        public AccountingStatement31Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement31Q3Validtor
        : AccountingStatement31Validtor
    {
        public AccountingStatement31Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement31Q4Validtor
        : AccountingStatement31Validtor
    {
        public AccountingStatement31Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement31Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type => ValidationStepType.AccountingStatement31Validtor;

        protected AccountingStatement31Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.ПрибУб.ЧистПрибУб.СумПред.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап
                       .ПредГод.УвеличКапитал.ЧистПриб.НераспПриб.ToDecimal()
                   ||
                   xsdReport.Документ.ПрибУб.ЧистПрибУб.СумПред.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап
                       .ПредГод.УменКапитал.Убыток.НераспПриб.ToDecimal();
        }
    }
}