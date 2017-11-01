using System.Linq;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;
using Microsoft.Practices.ServiceLocation;
using ReportsVerification.Web.Installers;
using ReportsVerification.Web.Utills;
using Unity.WebApi;

namespace ReportsVerification.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container
                .AddNewExtension<DefaultLifeTimeManagerContainerExtention>()
                .AddNewExtension<RepositoriesInstaller>()
                .AddNewExtension<MappersInstaller>()
                .AddNewExtension<BuildersInstaller>()
                .AddNewExtension<UtilsInstaller>()
                .AddNewExtension<FactoriesInstaller>()
                .AddNewExtension<ServicesInstaller>()
                .AddNewExtension<RecomendationsInstaller>();
            
            container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}