using System;
using System.Data;
using System.Configuration;
using System.Data.Common;

using System.Collections;
using System.Web.UI.WebControls;


namespace Web.HTTP.View.ApplicationObjects
{
    /// <summary>
    /// Load the languages...
    /// </summary>
    public class Languages
    {
        /* 
         * In a more realistic application, these values could be read from a 
         * database in the "static" contructor.
         */
        private static readonly ArrayList languages = new ArrayList();
       

        /* Access modifiers are not allowed on static constructors
         * so if we want to prevent that anybody creates instances 
         * of this class we must do the following ...
         */
        private Languages() { }

        static Languages()
        {
            #region set the languages

            languages.Add(new ListItem("es-ES"));          
            languages.Add(new ListItem("en-GB"));

            #endregion
        }

        public static ArrayList GetLanguages()
        {
             return languages;
        }

      
    }
}