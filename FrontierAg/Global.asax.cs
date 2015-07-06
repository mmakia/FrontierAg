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
using FrontierAg.Logic;

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

            // Add Routes.
            //RouteActions myRouteActions = new RouteActions();
            //myRouteActions.RegisterCustomRoutes(RouteTable.Routes);


            CssManager.CssResourceMapping.AddDefinition("juice-ui", new CssResourceDefinition
            {
                Path = "https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/ui-lightness/jquery-ui.css",
                DebugPath = "https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/ui-lightness/jquery-ui.css"
            });

            MetaModel DefaultModel = new MetaModel();
            DefaultModel.RegisterContext(new Microsoft.AspNet.DynamicData.ModelProviders.EFDataModelProvider(
                                         () => new ProductContext()),
                                         new ContextConfiguration { ScaffoldAllTables = false });

            
        }
        


    }
}