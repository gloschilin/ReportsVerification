using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 3 квартал заявлено возмещение. Готовьтесь к камеральной проверке
    /// </summary>
    public class Nds3Vosmechenie : CommonNdsVosmechenie
    {
        public Nds3Vosmechenie(IValidationHandler handler) : base(handler)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds3Vosmechenie;
        protected override int NdsQuarter => 3;
    }
}