using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Factories.Interfaces;
using ReportsVerification.Web.Factories.ReportInfoObjects;
using ReportsVerification.Web.Factories.Reports;

namespace ReportsVerification.Web.Installers
{
    public class FactoriesInstaller : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IReportFactory, ReportFactory>();
            Container.RegisterCollection<IConcreteReportFactory>();
            Container.RegisterType<IReportInfoFactory, ReportInfoFactory>();
        }
    }
}
