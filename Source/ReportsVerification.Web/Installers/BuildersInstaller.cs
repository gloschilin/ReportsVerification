using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Builders;
using ReportsVerification.Web.Builders.Interfaces;

namespace ReportsVerification.Web.Installers
{
    public class BuildersInstaller: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IReportInfoBuilder, ReportInfoBuilder>();
            Container.RegisterCollection<IConcreteReportInfoBuilder>();
        }
    }
}