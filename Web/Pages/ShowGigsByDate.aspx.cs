using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Reflection;



using Model.GigFacade;
using Util.Log;
using Model.GigDao;
using Model;

using Web.HTTP.Session;
using Web.HTTP.View.ApplicationObjects;

using Web.Properties;

using Microsoft.Practices.Unity;

using System.Xml;
using System.IO;

using Model.GigMusicTypeVo;
namespace Web.Pages
{
    public partial class ShowGigsByDate : SpecificCulturePage
    {
        ObjectDataSource pbpDataSource = new ObjectDataSource();
        private string file;
        IGigService gigService;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                /* Place the file in the App_Data subfolder of the current website.
                   The System.IO.Path class makes it easy to build the full file name.*/
                file = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Gigs.xml");

                // ObjectCreating is executed before ObjectDataSource creates 
                // an instance of the type used as DataSource (GigService).
                // We need to intercept this call to replace the standard creation
                // procedure (a new GigService() sentence) to use the Unity 
                // Container that allows to complete the dependences (gigDao,...)
                pbpDataSource.ObjectCreating += this.PbpDataSource_ObjectCreating;

                pbpDataSource.TypeName =
                    Properties.Settings.Default.ObjectDS_Gigs_Service; //Model.GigFacade.GigService

                pbpDataSource.EnablePaging = true;

                //pbpDataSource.SelectMethod = Properties.Settings.Default.ObjectDS_Gigs_SelectMethod;//FindGigsByDate
                pbpDataSource.SelectMethod = "GetGigsWithMusicType";
               

                /* Get the start date (without time) */
                DateTime startDate = Convert.ToDateTime(Request.Params.Get("startDate"));

                /* Get the end date (without time) */
                DateTime aux = Convert.ToDateTime(Request.Params.Get("endDate"));
                DateTime endDate = aux.AddSeconds(23 * 60 * 60 + 59 * 60 + 59);  // Adds 23:59:59

              
                pbpDataSource.SelectParameters.Add("startDate", DbType.DateTime, startDate.ToString());
                pbpDataSource.SelectParameters.Add("endDate", DbType.DateTime, endDate.ToString());

                pbpDataSource.SelectCountMethod =
                    Properties.Settings.Default.ObjectDS_Gigs_CountMethod;//GetNumberOfGigsByDate
                pbpDataSource.StartRowIndexParameterName =
                    Properties.Settings.Default.ObjectDS_Gigs_StartIndexParameter;//startIndex
                pbpDataSource.MaximumRowsParameterName =
                    Properties.Settings.Default.ObjectDS_Gigs_CountParameter;//count

                gvGigsByDate.AllowPaging = true;
                int count = Settings.Default.MiniGig_defaultCount;
                gvGigsByDate.PageSize = count;

                gvGigsByDate.DataSource = pbpDataSource;
                gvGigsByDate.DataBind();

            }
            catch (TargetInvocationException)
            {
                lblInvalidGig.Visible = true;
            }
        }

        protected void GvGigsByDatePageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGigsByDate.PageIndex = e.NewPageIndex;
            gvGigsByDate.DataBind();
            
        }

        protected void PbpDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {

            /* Get the Service */
            IUnityContainer container = (IUnityContainer)
                HttpContext.Current.Application["unityContainer"];

            // gigService is not resolved against the container because it
            // produce a proxy that it not available for databinding
            IGigService gigService = new GigService();
            gigService = (IGigService)
                container.BuildUp(gigService.GetType(), gigService);

            e.ObjectInstance = gigService;

        }
       
    }
}