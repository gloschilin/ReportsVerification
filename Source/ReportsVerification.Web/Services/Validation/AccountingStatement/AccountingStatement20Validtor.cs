using System;
using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    public class AccountingStatement20Q1Validtor
        : AccountingStatement20Validtor
    {
        public AccountingStatement20Q1Validtor(IValidationContext context) 
            : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    public class AccountingStatement20Q2Validtor
        : AccountingStatement20Validtor
    {
        public AccountingStatement20Q2Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    public class AccountingStatement20Q3Validtor
        : AccountingStatement20Validtor
    {
        public AccountingStatement20Q3Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    public class AccountingStatement20Q4Validtor
        : AccountingStatement20Validtor
    {
        public AccountingStatement20Q4Validtor(IValidationContext context)
            : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement20Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type 
            => ValidationStepType.AccountingStatement20Validtor;

        protected AccountingStatement20Validtor(IValidationContext context) : base(context)
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

            return kr.НераспПриб.СумПрдщ.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап
                       .ПредГод.Кап31дек.НераспПриб.ToDecimal();
        }
    }
}