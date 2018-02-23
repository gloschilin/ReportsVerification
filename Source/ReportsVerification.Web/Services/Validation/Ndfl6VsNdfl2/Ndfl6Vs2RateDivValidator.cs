using System.Linq;
using ReportsVerification.Web.DataObjects.Xsd.Ndfl6;
using ReportsVerification.Web.Extentions;
using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Ndfl6VsNdfl2
{
    public class Ndfl6Vs2Rate13DivValidator: Ndfl6Vs2RateDivValidator
    {
        public Ndfl6Vs2Rate13DivValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate13DivValidator;
        protected override int Rate => 13;
    }

    public class Ndfl6Vs2Rate15DivValidator : Ndfl6Vs2RateDivValidator
    {
        public Ndfl6Vs2Rate15DivValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl6Vs2Rate15DivValidator;
        protected override int Rate => 15;
    }

    public abstract class Ndfl6Vs2RateDivValidator : CommonValidator
    {
        protected abstract int Rate { get; }

        protected Ndfl6Vs2RateDivValidator(IValidationContext context) : base(context)
        {
        }
        
        protected override bool ValidateInternal(Файл ndfl6, DataObjects.Xsd.Ndfl2.Файл ndfl2)
        {
            var ndfl6Value = ndfl6.Документ.НДФЛ6.ОбобщПоказ.СумСтавка
                                 .FirstOrDefault(e => e.Ставка.ToInt() == Rate)?.НачислДохДив ?? 0;


            //ФайлДокументСведДохСвСумДох
            var ndfl2Value = ndfl2.Документ
                .SelectMany(e => e.СведДох)
                .Where(e => e.Ставка.ToInt() == Rate)
                .SelectMany(e=>e.ДохВыч)
                .Where(e=>e.КодДоход == "1010")
                .Sum(s => s.СумДоход);

            return ndfl2Value == ndfl6Value;
        }
    }
}