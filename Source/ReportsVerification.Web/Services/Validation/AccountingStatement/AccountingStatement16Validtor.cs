using System.Collections.Generic;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.DataObjects.Xsd.AccountingStatement;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.AccountingStatement
{
    [ValidatorQuarter(1)]
    public class AccountingStatement16Q1Validtor
        : AccountingStatement16Validtor
    {
        public AccountingStatement16Q1Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 1;
    }

    [ValidatorQuarter(2)]
    public class AccountingStatement16Q2Validtor
        : AccountingStatement16Validtor
    {
        public AccountingStatement16Q2Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 2;
    }

    [ValidatorQuarter(3)]
    public class AccountingStatement16Q3Validtor
        : AccountingStatement16Validtor
    {
        public AccountingStatement16Q3Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 3;
    }

    [ValidatorQuarter(4)]
    public class AccountingStatement16Q4Validtor
        : AccountingStatement16Validtor
    {
        public AccountingStatement16Q4Validtor(IValidationContext context) : base(context)
        {
        }

        protected override int Quarter => 4;
    }

    public abstract class AccountingStatement16Validtor
        : CommonValidator
    {
        protected override ValidationStepType Type
            => ValidationStepType.AccountingStatement16Validtor;

        protected AccountingStatement16Validtor(IValidationContext context) : base(context)
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

            return kr.РезКапитал.СумОтч.ToDecimal()
                   == xsdReport.Документ.ОтчетИзмКап.ДвиженКап.ОтчетГод.Кап31дек.РезКапитал.ToDecimal();
        }
    }
}