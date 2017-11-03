using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 2 квартал заявлено возмещение. Готовьтесь к камеральной проверке.
    /// </summary>
    public class Nds2Vosmechenie : CommonNdsVosmechenie
    {
        public Nds2Vosmechenie(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds2Vosmechenie;

        protected override int NdsQuarter => 2;
    }
}