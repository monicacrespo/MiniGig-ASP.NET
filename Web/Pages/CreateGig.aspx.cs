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

using Microsoft.Practices.Unity;

namespace Web.Pages
{
    public partial class CreateGig : SpecificCulturePage
    {
        IGigService gigService;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                #region Dependency Injection

                /* Get the Service */
                IUnityContainer container = (IUnityContainer)HttpContext.Current.Application["unityContainer"];
                gigService = container.Resolve<IGigService>();

                #endregion

                List<MusicType> types=  gigService.GetMusicTypes();
                this.ddlGigType.DataSource = types;
                this.ddlGigType.DataTextField = "description";
                this.ddlGigType.DataValueField = "typeId";
                this.ddlGigType.DataBind();
              

            }
        }
        protected void BtnCreateClick(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                /* Create a Gig. */
                String nameGig = txtGigName.Text;

                DateTime gigDate = Convert.ToDateTime(txtCal.Text);

                byte musicTypeId = Byte.Parse(this.ddlGigType.SelectedItem.Value);
                Gig gig = Gig.CreateGig(-1, nameGig, gigDate, musicTypeId);

               
                Gig createdGig;

                #region Delegate on factories
                /* Create an "GigService". */
                //IGigService gigService = GigServiceFactory.GetService();

              
                #endregion

                #region Dependency Injection

                /* Get the Service */
                IUnityContainer container = (IUnityContainer)HttpContext.Current.Application["unityContainer"];
                gigService = container.Resolve<IGigService>();

                #endregion

                createdGig = gigService.CreateGig(gig);

                Context.Items.Add("createdGig", createdGig);

                LogManager.RecordMessage("Gig " + createdGig.gigId + " created.", MessageType.Info);

                Server.Transfer(Response.ApplyAppPathModifier("./GigCreated.aspx"));
            }
        }
    }
}