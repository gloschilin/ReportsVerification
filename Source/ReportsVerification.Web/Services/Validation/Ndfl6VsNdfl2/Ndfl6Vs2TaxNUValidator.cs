using System;
using System.Linq;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl6;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Ndfl6VsNdfl2
{
    [ValidatorQuarter(4)]
    public class Ndfl6Vs2PersonsAmountValidator : CommonValidator
    {
        public Ndfl6Vs2PersonsAmountValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2PersonsAmountValidator;
        protected override bool ValidateInternal(Файл ndfl6, DataObjects.Xsd.Ndfl2.Файл ndfl2)
        {
            var ndfl6Value = ndfl6.Документ.НДФЛ6.ОбобщПоказ.КолФЛДоход.ToInt();
            var ndfl2Value = ndfl2.Документ.Count(e => e.КНД == "1151078");

            return ndfl2Value == ndfl6Value;
        }
    }

    [ValidatorQuarter(4)]
    public class Ndfl6Vs2TaxNuValidator: CommonValidator
    {
        public Ndfl6Vs2TaxNuValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2TaxNuValidator;
        protected override bool ValidateInternal(Файл ndfl6, 
            DataObjects.Xsd.Ndfl2.Файл ndfl2)
        {
            var ndfl6Value = ndfl6.Документ.НДФЛ6.ОбобщПоказ.НеУдержНалИт.ToDecimal();
            var ndfl2Value = ndfl2.Документ.Sum(e => e.СведДох.Sum(s => s.СумИтНалПер.НалНеУдерж));

            return ndfl2Value == ndfl6Value;
        }
    }
}