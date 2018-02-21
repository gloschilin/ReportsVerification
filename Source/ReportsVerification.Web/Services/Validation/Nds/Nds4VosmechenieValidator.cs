using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 3 квартал заявлено возмещение. Готовьтесь к камеральной проверке
    /// </summary>
    public class Nds4VosmechenieValidator : CommonNdsVosmechenieValidator
    {
        public Nds4VosmechenieValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds4VosmechenieValidator;
        protected override int Quarter => 3;
    }
}