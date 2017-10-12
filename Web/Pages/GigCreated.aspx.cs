using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.HTTP.Session;
using Model;


namespace Web.Pages
{
    public partial class GigCreated : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Gig createdGig = (Gig)Context.Items["createdGig"];
            lblGigCreatedId.Text = createdGig.gigId.ToString();
        }
       
    }
}