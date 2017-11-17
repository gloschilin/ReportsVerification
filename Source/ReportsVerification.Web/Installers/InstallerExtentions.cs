using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;

namespace ReportsVerification.Web.Installers
{
    public static class InstallerExtentions
    {
        /// <summary>
        /// Регистранция коллекций TCollectionInterface
        /// </summary>
        /// <typeparam name="TCollectionInterface"></typeparam>
        /// <param name="container"></param>
        public static void RegisterCollection<TCollectionInterface>(this IUnityContainer container)
        {
            container.RegisterType<IEnumerable<TCollectionInterface>, TCollectionInterface[]>();
            container.RegisterType<IReadOnlyCollection<TCollectionInterface>, TCollectionInterface[]>();

            var myTypeInterface = typeof(TCollectionInterface);

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
                container.RegisterType(myTypeInterface, type, type.Name);
            }
        }

    }
}