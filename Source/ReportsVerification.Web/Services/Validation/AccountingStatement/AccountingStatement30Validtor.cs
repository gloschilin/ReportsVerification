using System;
using System.Collections.Generic;
using System.Linq;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement30Q1Validtor
        : AccountingStatement30Validtor
    {
        public AccountingStatement30Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement30Q2Validtor
        : AccountingStatement30Validtor
    {
        public AccountingStatement30Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement30Q3Validtor
        : AccountingStatement30Validtor
    {
        public AccountingStatement30Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement30Q4Validtor
        : AccountingStatement30Validtor
    {
        public AccountingStatement30Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement30Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement30Validtor;

        protected AccountingStatement30Validtor(IValidationContext context) : base(context)
        {
        }

        protected override bool IsValid(Файл xsdReport,
            IReadOnlyCollection<Report> reports,
            SessionInfo sessionInfo)
        {
            return xsdReport.Документ.ПрибУб.ЧистПрибУб.СумОтч.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап
                       .ОтчетГод.УвеличКапитал.ЧистПриб.НераспПриб.ToDecimal()
                   ||
                   xsdReport.Документ.ПрибУб.ЧистПрибУб.СумОтч.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап
                       .ОтчетГод.УменКапитал.Убыток.НераспПриб.ToDecimal();
        }
    }
}