using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Web.HTTP.Session;
using Web.HTTP.View.ApplicationObjects;

using Model.GigFacade;
using Util.Log;
using Model.GigDao;
using Model;

using Util.Exceptions;
using System.Globalization;
namespace Web.Pages
{
    public partial class ShowGigByGigID : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Gig gig = (Gig)Context.Items["gig"];

            cellGigID.Text = gig.gigId.ToString();
            cellName.Text = gig.name.ToString();
            CultureInfo culture = CultureInfo.CurrentCulture;
            cellDate.Text = gig.date.ToShortDateString().ToString(culture);
            MusicType musicType = (MusicType)Context.Items["musicType"];

            //cellType.Text = gig.typeId.ToString();
            cellType.Text = musicType.description;
          
        }
    }
}