using ReportsVerification.Web.Services.Validation.Interfaces;

namespace ReportsVerification.Web.Services.Validation.Common
{
    public abstract class CommonConcretePrimaryReportValidator
        : CommonConcreteReportValidator, IConcretePrimaryReportValidator
    {
        protected CommonConcretePrimaryReportValidator(IValidationContext context) 
            : base(context)
        {
        }
    }
}