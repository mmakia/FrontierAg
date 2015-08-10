using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using FrontierAg.Models;
using System.Configuration;

namespace FrontierAg.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        string isSendEmails = ConfigurationManager.AppSettings["SendEmails"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (ProductContext db = new ProductContext())
                {
                    var allEmails = db.Emails.Where(r => r.isForOrder == true);

                    if (HttpContext.Current.Session["isStandOrder"] != null)
                    {
                        Label1.Text = "You just placed a Standing Order which is ordered by " + HttpContext.Current.Session["OrderedBy"].ToString();
                        if (isSendEmails == "1")
                        {
                            foreach (var a in allEmails)
                            {
                                new Emailer().SendEmail(a.EmailAddress, "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new standing order, Individual orders will appear under \"Open Orders\" list according to the dates set by the user, Please Click on the following link for Details(if any): http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                            }
                        }
                    }
                    else
                    {
                        Label1.Text = "You just placed order #" + HttpContext.Current.Session["OrderId"].ToString() + " which is ordered by " + HttpContext.Current.Session["OrderedBy"].ToString();

                        if (isSendEmails == "1")
                        {
                            foreach (var a in allEmails)
                            {
                                new Emailer().SendEmail(a.EmailAddress, "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                            }
                        }
                    }

                }

                //if (HttpContext.Current.Session["isStandOrder"] != null)
                //{
                //    Label1.Text = "You just placed a Standing Order which is ordered by " + HttpContext.Current.Session["OrderedBy"].ToString();
                //    new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new standing order, Individual orders will appear under \"Open Orders\" list according to the dates set by the user, Please Click on the following link for Details(if any): http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("mblack@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("ugatti@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("ddavis@fsiag.com", "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("mvella@fsiag.com", "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("mwoolman@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Standing Order, " + "Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //}
                //else
                //{
                //    Label1.Text = "You just placed order #" + HttpContext.Current.Session["OrderId"].ToString() + "which is ordered by " + HttpContext.Current.Session["OrderedBy"].ToString();
                //    new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("mblack@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("ugatti@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("ddavis@fsiag.com", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("mvella@fsiag.com ", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //    new Emailer().SendEmail("mwoolman@frontierssi.com ", "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                //}

                Session["isStandOrder"] = null;
                Session["OrderId"] = null;
                Session["OrderedBy"] = null;
            }

        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}