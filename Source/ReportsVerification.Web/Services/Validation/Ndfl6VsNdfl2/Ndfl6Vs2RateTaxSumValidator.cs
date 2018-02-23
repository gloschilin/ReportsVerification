using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl6;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Ndfl6VsNdfl2
{
    public class Ndfl6Vs2Rate13TaxSumValidator
        : Ndfl6Vs2RateTaxSumValidator
    {
        public Ndfl6Vs2Rate13TaxSumValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate13TaxSumValidator;
        protected override int Rate => 13;
    }

    public class Ndfl6Vs2Rate9TaxSumValidator
        : Ndfl6Vs2RateTaxSumValidator
    {
        public Ndfl6Vs2Rate9TaxSumValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate9TaxSumValidator;
        protected override int Rate => 9;
    }

    public class Ndfl6Vs2Rate15TaxSumValidator
        : Ndfl6Vs2RateTaxSumValidator
    {
        public Ndfl6Vs2Rate15TaxSumValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate15TaxSumValidator;
        protected override int Rate => 15;
    }

    public class Ndfl6Vs2Rate35TaxSumValidator
        : Ndfl6Vs2RateTaxSumValidator
    {
        public Ndfl6Vs2Rate35TaxSumValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate35TaxSumValidator;
        protected override int Rate => 35;
    }

    public abstract class Ndfl6Vs2RateTaxSumValidator : CommonValidator
    {
        protected abstract int Rate { get; }

        protected Ndfl6Vs2RateTaxSumValidator(IValidationContext context) : base(context)
        {
        }

        protected override bool ValidateInternal(Файл ndfl6, DataObjects.Xsd.Ndfl2.Файл ndfl2)
        {
            var ndfl6Value = ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка
                                 .FirstOrDefault(e => e.Ставка.ToInt() == Rate)?.ИсчислНал.ToDecimal() ?? 0;


            var ndfl2Value = ndfl2.Документ
                .SelectMany(e => e.СведДох)
                .Where(e => e.Ставка.ToInt() == Rate)
                .Sum(s => s.СумИтНалПер.НалИсчисл);

            return ndfl2Value == ndfl6Value;
        }
    }
}