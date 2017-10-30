using Microsoft.Practices.Unity;
using ReportsVerification.Web.Utills;
using ReportsVerification.Web.Utills.Interfaces;

namespace ReportsVerification.Web.Installers
{
    public class UtilsInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IRequestFileReader, RequestFileReader>();
        }
    }
}