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

                        //NotifyCustomer(HttpContext.Current.Session["OrderId"].ToString());
                    }

                }
                Session["isStandOrder"] = null;
                Session["OrderId"] = null;
                Session["OrderedBy"] = null;
            }

        }

        public void NotifyCustomer(string stringOrederId)
        {
            int orderId = 0;

            if (Int32.TryParse(stringOrederId, out orderId))
            {
                using (ProductContext db = new ProductContext())
                {
                    var OrderingshippingId = db.OrderShippings.Where(s => s.OrderId == orderId && s.SType == SType.Ordering).Select(q => q.ShippingId).SingleOrDefault();
                    var OrderingToEmail = db.Shippings.Where(r => r.ShippingId == OrderingshippingId).Select( u => u.EMail).SingleOrDefault();                    

                    var ShippingtoshippingId = db.OrderShippings.Where(s => s.OrderId == orderId && s.SType == SType.Shipping).Select(q => q.ShippingId).SingleOrDefault();
                    var ShippingToEmail = db.Shippings.Where(r => r.ShippingId == ShippingtoshippingId).Select(u => u.EMail).SingleOrDefault();

                    if (OrderingToEmail != ShippingToEmail)
                    {
                        //email Ordering person
                        new Emailer().SendEmail(OrderingToEmail, "orders@frontierssi.com", "Order Confirmation from Frontier Agricultural Sciences", "Hello,\n\nThank you for shopping with us.\nYou order has been placed. \nYour order number is " + orderId + ". \n\nFeel free to contact us if you have any question.\n http://www.insectrearing.com/contact.html");
                        
                        //email ShippingTo person
                        new Emailer().SendEmail(ShippingToEmail, "orders@frontierssi.com", "Order Confirmation from Frontier Agricultural Sciences", "Hello,\n\nAn order has been placed to be shipped to you.\nThe order number is " + orderId + ".\nYou will receive a confirmation email when your order ships.\n\nFeel free to contact us if you have any question.\n http://www.insectrearing.com/contact.html");
                    }
                    else
                    {
                        //email customer(Ordering person is the same as shippingTo person)
                        new Emailer().SendEmail(OrderingToEmail, "orders@frontierssi.com", "Order Confirmation from Frontier Agricultural Sciences", "Hello,\n\nThank you for shopping with us.\nYou order number is " + orderId + ".\nYou will receive a confirmation email when your order ships.\n\nFeel free to contact us if you have any question.\n http://www.insectrearing.com/contact.html");
                    }
                    
                }
            }
            
        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}