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


using Microsoft.Practices.Unity;

namespace Web.Pages
{
    public partial class FindGig : SpecificCulturePage
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            lblIdentifierError.Visible = false;
        }

        protected void BtnFindClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get data. */
                
                Int32 identifier = Convert.ToInt32(this.txtIdentifier.Text);

                /* Do action. */
                FindGigByGigIdentifier(identifier);
               
            }
    }

           /// <summary>
        /// Finds the gig by gig identifier.
        /// The gig is stored in context and the request is redirected
        /// to ShowGigByAccID which will show it.
        /// </summary>
        /// <param name="gigIdentifier">The gig identifier.</param>
        private void FindGigByGigIdentifier(int gigIdentifier)
        {
            try
            {

                #region Unity

                /* Get the Service */
                IUnityContainer container = (IUnityContainer)HttpContext.Current.Application["unityContainer"];
                IGigService gigService = container.Resolve<IGigService>();
                
                Gig gig = gigService.FindGig(gigIdentifier);
                MusicType musicType = gigService.FindMusicType(gig.typeId);
                #endregion
                
                #region Delegate on factories
                ///* Create an "GigService". */
                //IGigService gigService = GigServiceFactory.GetService();

                ///* Get Gig Data */
                //GigVO gig = gigService.FindGig(gigIdentifier);

                #endregion
             
                /* Attach data to context */
                Context.Items.Add("gig", gig);
                Context.Items.Add("musicType", musicType); 
              
                /* Redirect to Visualization WebForm */
                Server.Transfer(Response.ApplyAppPathModifier("./ShowGigByGigID.aspx"));
            }
            catch (InstanceNotFoundException)
            {
                lblIdentifierError.Visible = true;
            }
        }

    }
}