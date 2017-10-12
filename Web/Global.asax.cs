using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();

            /*
             * We read the UnityConfigurationSection from the default 
             * configuration file, and then populate the UnityContainer.
             */
            IUnityContainer container = new UnityContainer();
         
            UnityConfigurationSection section =
                (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            section.Containers.Default.Configure(container);

            Application["UnityContainer"] = container;

            Application.UnLock();

        }

        protected void Application_End(object sender, EventArgs e)
        {
            ((UnityContainer)Application["UnityContainer"]).Dispose();

        }
    }
}