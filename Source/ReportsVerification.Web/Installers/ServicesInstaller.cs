using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services;
using ReportsVerification.Web.Services.Interfaces;

namespace ReportsVerification.Web.Installers
{
    public class ServicesInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IReportsService, ReportsService>();
        }
    }
}