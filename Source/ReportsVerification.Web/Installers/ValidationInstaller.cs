using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds;
using ReportsVerification.Web.Services.Validation.PrimaryValidation;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Installers
{
    public class ValidationInstaller : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IValidationContext, HttpValidationContext>();
            Container.RegisterType<IReportsValidator, ReportsValidator>();
            Container.RegisterType<IEnumerable<IConcreteReportValidator>, IConcreteReportValidator[]>();

            //TODO:
            Container.RegisterType<IConcreteReportValidator, DirectCosts1Validator>("DirectCosts1Validator");
            Container.RegisterType<IConcreteReportValidator, DirectCosts2Validator>("DirectCosts2Validator");
            Container.RegisterType<IConcreteReportValidator, DirectCosts3Validator>("DirectCosts3Validator");
            Container.RegisterType<IConcreteReportValidator, Loss1Validator>("Loss1Validator");
            Container.RegisterType<IConcreteReportValidator, Loss2Validator>("Loss2Validator");
            Container.RegisterType<IConcreteReportValidator, Loss3Validator>("Loss3Validator");
            Container.RegisterType<IConcreteReportValidator, RevenuesNds1Validator>("RevenuesNds1Validator");
            Container.RegisterType<IConcreteReportValidator, RevenuesNds2Validator>("RevenuesNds2Validator");
            Container.RegisterType<IConcreteReportValidator, RevenuesNds3Validator>("RevenuesNds3Validator");
            Container.RegisterType<IConcreteReportValidator, Nds1DeductionValidator>("Nds1DeductionValidator");
            Container.RegisterType<IConcreteReportValidator, Nds2DeductionValidator>("Nds2DeductionValidator");
            Container.RegisterType<IConcreteReportValidator, Nds3DeductionValidator>("Nds3DeductionValidator");
            Container.RegisterType<IConcreteReportValidator, Nds1VosmechenieValidator>("Nds1VosmechenieValidator");
            Container.RegisterType<IConcreteReportValidator, Nds2VosmechenieValidator>("Nds2VosmechenieValidator");
            Container.RegisterType<IConcreteReportValidator, Nds3VosmechenieValidator>("Nds3VosmechenieValidator");

            Container.RegisterType<IPrimaryReportsValidator, PrimaryReportsValidator>();
            Container.RegisterType<IEnumerable<IConcretePrimaryReportValidator>, IConcretePrimaryReportValidator[]>();
            Container.RegisterType<IConcretePrimaryReportValidator, IsUniqueReportValidator>("IsUniqueReportValidator");
            Container.RegisterType<IConcretePrimaryReportValidator, ByYearReportValidator>("ByYearReportValidator");
            Container.RegisterType<IConcretePrimaryReportValidator, ByInnReportValidator>("ByInnReportValidator");

        }
    }
}