using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model.GigFacade;
using Util.Log;
using Model.GigDao;
using Model;

using Web.HTTP.Session;
using Web.HTTP.View.ApplicationObjects;
using Util.Exceptions;

using Microsoft.Practices.Unity;

namespace Web.Pages
{
    public partial class RemoveGig : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIdentifierError.Visible = false;
        }

        protected void BtnRemoveClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                /* Get identifier. */
                int gigIdentifier = Convert.ToInt32(txtIdentifier.Text);

                /* Do action. */
                try
                {
                    #region Unity
                    /* Get the Service */
                    IUnityContainer container = (IUnityContainer)HttpContext.Current.Application["unityContainer"];
                    IGigService gigService = container.Resolve<IGigService>();
                    gigService.RemoveGig(gigIdentifier);
                    #endregion

                    #region Delegate on factories
                    /* Create an "GigService". */
                    //IGigService gigService = GigServiceFactory.GetService();
                    //gigService.RemoveGig(gigIdentifier);
                    #endregion
                   

                    Response.Redirect(Response.ApplyAppPathModifier("./SuccessfulOperation.aspx"));
                }
                catch (InstanceNotFoundException)
                {
                    lblIdentifierError.Visible = true;
                }
            }
        }
    }
}