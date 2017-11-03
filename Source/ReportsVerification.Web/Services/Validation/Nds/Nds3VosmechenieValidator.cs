using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 3 квартал заявлено возмещение. Готовьтесь к камеральной проверке
    /// </summary>
    public class Nds3VosmechenieValidator : CommonNdsVosmechenieValidator
    {
        public Nds3VosmechenieValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds3VosmechenieValidator;
        protected override int NdsQuarter => 3;
    }
}