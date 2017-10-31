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
            Container.RegisterType<IEnumerable<IConcreteReportInfoBuilder>, IConcreteReportInfoBuilder[]>();
            Container.RegisterType<IConcreteReportInfoBuilder, Ndfl6InfoBuilder>("Ndfl6InfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, AccountingStatementInfoBuilder>("AccountingStatementInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, AccountingStatementSimplifiedTaxationInfoBuilder>("AccountingStatementSimplifiedTaxationInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, CalculationAdvancePaymentInfoBuilder>("CalculationAdvancePaymentInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, CalculationContributionsInfoBuilder>("CalculationContributionsInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, DeclarationOnIncomeTaxInfoBuilder>("DeclarationOnIncomeTaxInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, DeclarationOnLandTaxInfoBuilder>("DeclarationOnLandTaxInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, DeclarationOnPropertyTaxInfoBuilder>("DeclarationOnPropertyTaxInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, EnvdInfoBuilder>("EnvdInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, Ndfl2InfoBuilder>("Ndfl2InfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, SzvMInfoBuilder>("SzvMInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, TransportDeclarationInfoBuilder>("TransportDeclarationInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, UsnInfoBuilder>("UsnInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, Fss4Builder>("Fss4Builder");
            Container.RegisterType<IConcreteReportInfoBuilder, NdsInfoBuilder>("NdsInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, PurchasesBookNdsInfoBuilder>("PurchasesBookNdsInfoBuilder");
            Container.RegisterType<IConcreteReportInfoBuilder, SalesBookNdsInfoBuilder>("SalesBookNdsInfoBuilder");
        }
    }
}