using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services;
using ReportsVerification.Web.Services.Interfaces;
using ReportsVerification.Web.Services.Recomendations;

namespace ReportsVerification.Web.Installers
{
    public class RecomendationsInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IRecomendationsService, RecomendationsService>();
            Container.RegisterType<IEnumerable<IConcreteRecomendation>, IConcreteRecomendation[]>();
            Container.RegisterType<IConcreteRecomendation, CalculationContributionsRecomendation>("CalculationContributionsRecomendation");
            Container.RegisterType<IConcreteRecomendation, DeclarationOnIncomeTaxRecomendations>("DeclarationOnIncomeTaxRecomendations");
            Container.RegisterType<IConcreteRecomendation, EndvRecomendations>("EndvRecomendations");
            Container.RegisterType<IConcreteRecomendation, ForNdsRecomendations>("ForNdsRecomendations");
            Container.RegisterType<IConcreteRecomendation, Fss4Recomendation>("Fss4Recomendation");
            Container.RegisterType<IConcreteRecomendation, Ndfl6Recomendation>("Ndfl6Recomendation");
            Container.RegisterType<IConcreteRecomendation, SzvmRecomendation>("SzvmRecomendation");
        }
    }
}