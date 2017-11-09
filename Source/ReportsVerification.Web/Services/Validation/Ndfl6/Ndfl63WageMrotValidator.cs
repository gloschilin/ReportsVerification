using ReportsVerification.Web.Repositories.Interfaces;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Ndfl6.Common;

namespace ReportsVerification.Web.Services.Validation.Ndfl6
{
    public class Ndfl63WageMrotValidator : NdflWageMrotValidator
    {
        public Ndfl63WageMrotValidator(IValidationContext context, ICatalogRepository catalogRepository) 
            : base(context, catalogRepository)
        {
        }

        protected override ValidationStepType Type => ValidationStepType.Ndfl63WageMrotValidator;
        protected override int Quarter => 3;
    }
}