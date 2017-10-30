using Microsoft.Practices.Unity;
using ReportsVerification.Web.DataObjects;
using ReportsVerification.Web.Mappers;
using ReportsVerification.Web.Mappers.Interfaces;
using ReportsVerification.Web.Models;

namespace ReportsVerification.Web.Installers
{
    public class MappersInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMapper<Report, Repositories.EF.Report>, ReportMapper>();
            Container.RegisterType<IMapper<Repositories.EF.Session, SessionInfo>, SessionMapper>();
            Container.RegisterType<IEntityMapper<SessionInfo, Repositories.EF.Session, Repositories.EF.ReportsVertification>, SessionMapper>();
            Container.RegisterType<IMapper<SessionInfoModel, SessionInfo>, SessionMapper>();
            Container.RegisterType<IMapper<SessionInfo, SessionInfoModel>, SessionMapper>();
        }
    }
}