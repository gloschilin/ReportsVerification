using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Installers
{
    public class ValidationInstaller : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IValidationContext, HttpValidationContext>();
            Container.RegisterType<IReportsValidator, ReportsValidator>();
            Container.RegisterType<IPrimaryReportsValidator, PrimaryReportsValidator>();
            Container.RegisterCollection<IConcreteReportValidator>();
            Container.RegisterCollection<IConcretePrimaryReportValidator>();
        }

    }
}