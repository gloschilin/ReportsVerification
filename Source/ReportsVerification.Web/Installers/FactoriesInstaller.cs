using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Factories;
using ReportsVerification.Web.Factories.Interfaces;

namespace ReportsVerification.Web.Installers
{
    public class FactoriesInstaller : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IReportFactory, ReportFactory>();
            Container.RegisterType<IEnumerable<IConcreteReportFactory>, IConcreteReportFactory[]> ();
            Container.RegisterType<IConcreteReportFactory, AccountingStatementFactory>("AccountingStatementFactory");
            Container.RegisterType<IConcreteReportFactory, AccountingStatementSimplifiedTaxationFactory>("AccountingStatementSimplifiedTaxationFactory");
            Container.RegisterType<IConcreteReportFactory, CalculationAdvancePaymentFactory>("CalculationAdvancePaymentFactory");
            Container.RegisterType<IConcreteReportFactory, CalculationContributionsFactory>("CalculationContributionsFactory");
            Container.RegisterType<IConcreteReportFactory, DeclarationOnIncomeTaxFactory>("DeclarationOnIncomeTaxFactory");
            Container.RegisterType<IConcreteReportFactory, DeclarationOnLandTaxFactory>("DeclarationOnLandTaxFactory");
            Container.RegisterType<IConcreteReportFactory, DeclarationOnPropertyTaxFactory>("DeclarationOnPropertyTaxFactory");
            Container.RegisterType<IConcreteReportFactory, EnvdFactory>("EnvdFactory");
            Container.RegisterType<IConcreteReportFactory, Ndfl2Factory>("Ndfl2Factory");
            Container.RegisterType<IConcreteReportFactory, Ndfl6Factory>("Ndfl6Factory");
            Container.RegisterType<IConcreteReportFactory, NdsFactory>("NdsFactory");
            Container.RegisterType<IConcreteReportFactory, SzvMFactory>("SzvMFactory");
            Container.RegisterType<IConcreteReportFactory, TransportDeclarationFactory>("TransportDeclarationFactory");
            Container.RegisterType<IConcreteReportFactory, UsnFactory>("UsnFactory");
        }
    }
}
