using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services;
using ReportsVerification.Web.Services.Interfaces;
using ReportsVerification.Web.Services.ReportsRecomendations;

namespace ReportsVerification.Web.Installers
{
    public class RecomendationsInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ISessionInfoRecomendationsService, SessionInfoRecomendationsService>();
            Container.RegisterCollection<IConcreteSessionInfoRecomendation>();

            Container.RegisterType<IReportsRecomendations, ReportsRecomendations>();
            Container.RegisterCollection<IReportsConcreteRecomendations>();
        }
    }
}