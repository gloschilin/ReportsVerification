using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    public class Ndfl61WageMrotValidator : NdflWageMrotValidator
    {
        public Ndfl61WageMrotValidator(IValidationContext context, ICatalogRepository catalogRepository)
            : base(context, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl61WageMrotValidator;
        protected override int Quarter => 1;
    }
}