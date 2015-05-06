using FrontierAg.Models;
using Juice.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FrontierAg
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            //Database.SetInitializer(new ProductDatabaseInitializer());

            // Create the custom role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole();
            CssManager.CssResourceMapping.AddDefinition("juice-ui", new CssResourceDefinition
            {
                Path = "~/Content/themes/ui-lightness/jquery-ui.css",
                DebugPath = "~/Content/themes/ui-lightness/jquery-ui.css"
            });

            MetaModel DefaultModel = new MetaModel();
            DefaultModel.RegisterContext(new Microsoft.AspNet.DynamicData.ModelProviders.EFDataModelProvider(
                                         () => new ProductContext()),
                                         new ContextConfiguration { ScaffoldAllTables = false });
        }
        //void Application_Error(object sender, EventArgs e)
        //{
        //    // Code that runs when an unhandled error occurs.

        //    // Get last error from the server
        //    Exception exc = Server.GetLastError();

        //    if (exc is HttpUnhandledException)
        //    {
        //        if (exc.InnerException != null)
        //        {
        //            exc = new Exception(exc.InnerException.Message);
        //            Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
        //                true);
        //        }
        //    }
        //}
    }
}