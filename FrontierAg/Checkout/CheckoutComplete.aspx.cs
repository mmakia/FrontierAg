using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace FrontierAg.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["isStandOrder"] != null)
                {
                    //new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order", "There is a new standing order, Individual orders will appear under \"Open Orders\" list according to the dates set by the user, Please Click on the following link for Details(if any): http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("snacko@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("ugatti@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("ddavis@fsiag.com", "orders@frontierssi.com", "FrontierAg New Standing Order", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("mvella@fsiag.com ", "orders@frontierssi.com", "FrontierAg New Standing Order", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("mwoolman@frontierssi.com ", "orders@frontierssi.com", "FrontierAg New Standing Order", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                }
                else
                {

                    //new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("snacko@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("ugatti@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("ddavis@fsiag.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("mvella@fsiag.com ", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                    //new Emailer().SendEmail("mwoolman@frontierssi.com ", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                }

                Session["isStandOrder"] = null;
                Session["OrderId"] = null;
            }

        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}