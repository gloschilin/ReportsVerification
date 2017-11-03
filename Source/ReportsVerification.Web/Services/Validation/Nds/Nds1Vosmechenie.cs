using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 1 квартал заявлено возмещение. Готовьтесь к камеральной проверке.
    /// Ссылки на статьи
    /// </summary>
    public class Nds1Vosmechenie: CommonNdsVosmechenie
    {
        public Nds1Vosmechenie(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds1Vosmechenie;
        protected override int NdsQuarter => 1;
    }
}