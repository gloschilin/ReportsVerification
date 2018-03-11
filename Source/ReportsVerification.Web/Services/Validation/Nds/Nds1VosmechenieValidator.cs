using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds.Common;

namespace ReportsVerification.Web.Services.Validation.Nds
{
    /// <summary>
    /// В декларации по НДС за 1 квартал заявлено возмещение. Готовьтесь к камеральной проверке.
    /// Ссылки на статьи
    /// </summary>
    [ValidatorQuarter(1)]
    public class Nds1VosmechenieValidator: CommonNdsVosmechenieValidator
    {
        public Nds1VosmechenieValidator(IValidationContext context) : base(context)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Nds1VosmechenieValidator;
        protected override int Quarter => 1;
    }
}