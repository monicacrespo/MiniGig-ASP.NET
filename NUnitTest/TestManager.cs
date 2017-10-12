using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Test
{
    public class TestManager
    {
        public static IUnityContainer ConfigureUnityContainer(string sectionName)
        {
            IUnityContainer container = new UnityContainer();

            UnityConfigurationSection section =
                (UnityConfigurationSection)ConfigurationManager.GetSection(sectionName);

            section.Containers.Default.Configure(container);

            return container;
        }


        public static void ClearUnityContainer(IUnityContainer container)
        {
            container.Dispose();
        }
    }
}
