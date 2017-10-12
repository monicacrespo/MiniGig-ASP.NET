using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.GigFacade;
using Util.Log;
using Model.GigDao;

using Web.HTTP.Session;
using Web.HTTP.View.ApplicationObjects;

using System.Globalization;

namespace Web.Pages
{
    public partial class FindGigs : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                /* Get data. */
               

                string strStartDate;
                strStartDate = txtCalStartDate.Text;
                string strEndDate;
                strEndDate = txtCalEndDate.Text;
                DateTime startDate = DateTime.Parse(strStartDate, CultureInfo.CurrentCulture);

                DateTime endDate = DateTime.Parse(strEndDate, CultureInfo.CurrentCulture);
               

                /* Do action. */
                String url =
                    String.Format("./ShowGigsByDate.aspx?" +
                        "&startDate={0}&endDate={1}", startDate.ToShortDateString(), endDate.ToShortDateString());

                Response.Redirect(Response.ApplyAppPathModifier(url));
            }
        }



    }
}