using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;
using Web.HTTP.View.ApplicationObjects;
using Util.Log;

using System.Globalization;

namespace Web.Pages
{
    public partial class SetLocale : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String language;
            String country;

            if (!IsPostBack)
            {
                /* 
                 * We check if exists a locale in the session. In this case, 
                 * we get the language and the region/country from the locale.
                 * Othercase we use the browser preferences to extract the
                 * language and the region/country
                 */
                if (!SessionManager.IsLocaleDefined(Context))
                {
                    /* Gets preferred language from browser */
                    language = GetLanguageFromBrowserPreferences();
                    country = GetCountryFromBrowserPreferences();
                }
                else
                {
                    Locale locale = SessionManager.GetLocale(Context);
                    language = locale.Language;
                    country = locale.Country;
                }

                /* Finally we update the data of the "Combo", using the
                 * selected laguage and region/country.
                 */
                String culture = language + "-" + country;
                UpdateComboLanguage(culture);
               
            }
        }

        private String GetLanguageFromBrowserPreferences()
        {
            String language;
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
            language = cultureInfo.TwoLetterISOLanguageName;
            LogManager.RecordMessage("Preferred language of user (based on browser preferences): " + language);
            return language;
        }

        private String GetCountryFromBrowserPreferences()
        {
            String country;
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);

            if (cultureInfo.IsNeutralCulture)
            {
                country = "";
            }
            else
            {
                // cultureInfoName is something like en-US
                String cultureInfoName = cultureInfo.Name;
                // Gets the last two caracters of cultureInfoname
                country = cultureInfoName.Substring(cultureInfoName.Length - 2);

                LogManager.RecordMessage("Preferred region/country of user (based on browser preferences): " + country);
            }

            return country;
        }

        /// <summary>
        /// Loads the languages in the comboBox in the *selectedLanguage*. 
        /// Also, the selectedLanguage will appear selected in the 
        /// ComboBox
        /// </summary>
        private void UpdateComboLanguage(String selectedLanguage)
        {
           
            this.comboLanguage.DataSource = Languages.GetLanguages();
            this.comboLanguage.DataTextField = "text";
            this.comboLanguage.DataValueField = "value";
            this.comboLanguage.DataBind();
            this.comboLanguage.SelectedValue = selectedLanguage;
        }



        protected void BtnSetLocaleClick(object sender, EventArgs e)
        {
            string culture = comboLanguage.SelectedValue;

            string language = culture.Substring(0, 2);
            // cultureInfoName is something like en-US
            // Gets the last two caracters of cultureInfoname
            string country = culture.Substring(culture.Length - 2);
           
            Locale locale = new Locale(language, country);

            SessionManager.SetLocale(Context, locale);

            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/MainPage.aspx"));
        }

      

        
    }
}