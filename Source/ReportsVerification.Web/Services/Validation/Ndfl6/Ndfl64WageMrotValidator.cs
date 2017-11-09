using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    public class Ndfl64WageMrotValidator : NdflWageMrotValidator
    {
        public Ndfl64WageMrotValidator(IValidationContext context, ICatalogRepository catalogRepository)
            : base(context, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl64WageMrotValidator;
        protected override int Quarter => 4;
    }
}