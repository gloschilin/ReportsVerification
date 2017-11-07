using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 2 квартал заявлено возмещение. Готовьтесь к камеральной проверке.
    /// </summary>
    public class Nds2VosmechenieValidator : CommonNdsVosmechenieValidator
    {
        public Nds2VosmechenieValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds2VosmechenieValidator;

        protected override int Quarter => 2;
    }
}