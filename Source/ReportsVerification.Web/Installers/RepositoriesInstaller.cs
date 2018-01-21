using Microsoft.Practices.Unity;
using ReportsVerification.Web.Repositories;
using ReportsVerification.Web.Repositories.Interfaces;

namespace ReportsVerification.Web.Installers
{
    public class RepositoriesInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICatalogRepository, CatalogsRepository>();
            Container.RegisterType<ISessionRepository, SessionRepository>();
            Container.RegisterType<IReportRepository, ReportsRepository>();
            Container.RegisterType<IMessagesRepository, MessagesRepository>();
        }
    }
}