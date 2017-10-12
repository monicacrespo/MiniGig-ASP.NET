using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;


using Web.HTTP.Session;
using Web.HTTP.View.ApplicationObjects;
using Util.Log;
using System.Globalization;

namespace Web.HTTP.Session
{
    /// <summary>
    /// This class selects the cultural preferences of the Web application
    /// </summary>
    public class SpecificCulturePage : Page
    {
        /// <summary>
        /// Initializes the cultural preferences
        /// </summary>
        protected override void InitializeCulture()
        {
            /* If the user had selected a specific language (from an 
             * application option of from a stored profile) the Web application
             * will use the culture selected by the user. Otherwise, the 
             * cultural preferences established in the Web browser will be 
             * used.
             * If *Locale* is defined in the session, then we use that locale
             * to override the Culture of the application. Otherwise, we will 
             * not do anything and the framework will behave based on 
             * configuration on Web.config or page level
             */
            if (SessionManager.IsLocaleDefined(Context))
            {
                Locale locale = SessionManager.GetLocale(Context);

                String culture = locale.Language + "-" + locale.Country;
                CultureInfo cultureInfo;

                /* 
                 * The method CreateSpecificCulture will try to create a 
                 * specific culture based on the combination selected by the 
                 * user (i.e. <laguageCode2>-<country/regionCode2>). If the 
                 * combination is not a valid culture, it will create a 
                 * specific culture using 1) the languague and 2) the default 
                 * region for that language. For example, if user selects 
                 * gl-GB (wich is not a valid culture), an en-ES specific 
                 * culture will be created 
                 */
                try
                {
                    cultureInfo = CultureInfo.CreateSpecificCulture(culture);
                    LogManager.RecordMessage("Specific culture created: " + cultureInfo.Name);


                }
                /* 
                 * If any error occurs we will create a default culture 
                 * "en-GB". This exception should never happen.
                 */
                catch (ArgumentException)
                {
                    cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                }
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

            }
        }
    }
}
