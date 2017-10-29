using Microsoft.Practices.Unity;
using System.Web.Http;
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
                .AddNewExtension<BuildersInstaller>()
                .AddNewExtension<FactoriesInstaller>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}