using System.Collections.Generic;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services.Validation.DeclarationOnIncomeTax;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Services.Validation.Nds;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Installers
{
    public class ValidationInstaller : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IValidationHandler, HttpValidationHandler>();
            Container.RegisterType<IReportsValidationService, IReportsValidationService>();
            Container.RegisterType<IEnumerable<IReportsConcreteValidationService>, IReportsConcreteValidationService[]>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxDirectCosts1Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxDirectCosts2Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxDirectCosts3Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxLoss1Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxLoss2Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxLoss3Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxRevenuesNds1Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxRevenuesNds2Validation>();
            Container.RegisterType<IReportsConcreteValidationService, DeclarationOnIncomeTaxRevenuesNds3Validation>();
            Container.RegisterType<IReportsConcreteValidationService, Nds1Deduction>();
            Container.RegisterType<IReportsConcreteValidationService, Nds2Deduction>();
            Container.RegisterType<IReportsConcreteValidationService, Nds3Deduction>();
            Container.RegisterType<IReportsConcreteValidationService, Nds1Vosmechenie>();
            Container.RegisterType<IReportsConcreteValidationService, Nds2Vosmechenie>();
            Container.RegisterType<IReportsConcreteValidationService, Nds3Vosmechenie>();
        }
    }
}