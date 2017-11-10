using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using ReportsVerification.Web.Services.Validation;
using ReportsVerification.Web.Services.Validation.Interfaces;
using ReportsVerification.Web.Utills;

namespace ReportsVerification.Web.Installers
{
    public class ValidationInstaller : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IValidationContext, HttpValidationContext>();
            Container.RegisterType<IReportsValidator, ReportsValidator>();
            Container.RegisterType<IEnumerable<IConcreteReportValidator>, IConcreteReportValidator[]>();
            Container.RegisterType<IPrimaryReportsValidator, PrimaryReportsValidator>();
            Container.RegisterType<IEnumerable<IConcretePrimaryReportValidator>, IConcretePrimaryReportValidator[]>();

            RegisterValidators<IConcreteReportValidator>();
            RegisterValidators<IConcretePrimaryReportValidator>();
        }

        private void RegisterValidators<TInterface>()
        {
            var myTypeInterface = typeof(TInterface);

            if (!myTypeInterface.IsInterface)
            {
                throw new ApplicationException($"{myTypeInterface} is not interface");
            }

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => myTypeInterface.IsAssignableFrom(p) && !p.IsAbstract);

            foreach (var type in types)
            {
                Debug.WriteLine($"Register {myTypeInterface} is {type} by name {type.Name}");
                Container.RegisterType(myTypeInterface, type, type.Name);
            }
        }
    }
}