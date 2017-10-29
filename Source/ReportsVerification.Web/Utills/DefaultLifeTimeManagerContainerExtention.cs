using Microsoft.Practices.Unity;

namespace ReportsVerification.Web.Utills
{
    /// <summary>
    /// Установка LifeTimeManager по умолчанию 
    /// </summary>
    public class DefaultLifeTimeManagerContainerExtention: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Registering += ContextRegistering;
        }

        private static void ContextRegistering(object sender, RegisterEventArgs e)
        {
            e.LifetimeManager = e.LifetimeManager ?? new ContainerControlledLifetimeManager();
        }
    }
}