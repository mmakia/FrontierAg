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
        string isSendStaffEmails = ConfigurationManager.AppSettings["SendEmails"];        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ItemsOrdered = getItemsOrdered(HttpContext.Current.Session["OrderId"].ToString());

                using (ProductContext db = new ProductContext())
                {
                    var allEmails = db.Emails.Where(r => r.isForOrder == true);

                    if (HttpContext.Current.Session["isStandOrder"] != null)
                    {
                        Label1.Text = "You just placed a Standing Order which is ordered by " + HttpContext.Current.Session["OrderedBy"].ToString();

                        if (isSendStaffEmails == "1")
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

                        if (isSendStaffEmails == "1")
                        {
                            foreach (var a in allEmails)
                            {
                                new Emailer().SendEmail(a.EmailAddress, "orders@frontierssi.com", "FrontierAg New Order #" + HttpContext.Current.Session["OrderId"] + ", Ordered By " + HttpContext.Current.Session["OrderedBy"], "<p style='color: #CC0000;'>Hello,</p>There is a new Order.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");//"There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
                            }
                        }

                        EmailCustomers(HttpContext.Current.Session["OrderId"].ToString());
                    }                    
                }
                Session["isStandOrder"] = null;
                Session["OrderId"] = null;
                Session["OrderedBy"] = null;
                Session["EmailOrderingCustomer"] = null;
                Session["EmailShpToCustomer"] = null;
            }

        }


        public string getItemsOrdered(string stringOrederId)
        {
             int orderId = 0;

             if (Int32.TryParse(stringOrederId, out orderId))
             {
                 using (ProductContext db = new ProductContext())
                 {
                     //getting the items ordered
                     var ProductNos = db.OrderDetails.Where(w => w.OrderId == orderId).Select(e => e.Product.ProductNo).ToArray();
                     var ProductNames = db.OrderDetails.Where(w => w.OrderId == orderId).Select(e => e.Product.ProductName).ToArray();
                     var Quantities = db.OrderDetails.Where(w => w.OrderId == orderId).Select(e => e.Quantity).ToArray();
                     string strBodyHeader = "<table style='padding:5px 20px 0px 0px' ><tr style='text-decoration:underline;'><td> Product Number </td><td> Product Name </td><td> Quantity </td></tr>";
                     string strBodyContent = "";
                     for (int i = 0; i < ProductNos.Length; i++)
                     {
                         strBodyContent += "<tr><td>" + ProductNos[i] + "</td><td>" + ProductNames[i] + "</td><td align=\"center\">" + Quantities[i] + "</td></tr>";
                     }
                     string strBodyFooter = "</table>";
                     string messageBody = strBodyHeader + strBodyContent + strBodyFooter;
                     return messageBody;
                 }
             }
             return "";
        }

        public void EmailCustomers(string stringOrederId)
        {
            int orderId = 0;
            string ItemsOrdered = getItemsOrdered(HttpContext.Current.Session["OrderId"].ToString());

            if (Int32.TryParse(stringOrederId, out orderId))
            {
                using (ProductContext db = new ProductContext())
                {
                    var OrderingshippingId = db.OrderShippings.Where(s => s.OrderId == orderId && s.SType == SType.Ordering).Select(q => q.ShippingId).SingleOrDefault();
                    var OrderingToEmail = db.Shippings.Where(r => r.ShippingId == OrderingshippingId).Select( u => u.EMail).SingleOrDefault();                    

                    var ShippingtoshippingId = db.OrderShippings.Where(s => s.OrderId == orderId && s.SType == SType.Shipping).Select(q => q.ShippingId).SingleOrDefault();
                    var ShippingToEmail = db.Shippings.Where(r => r.ShippingId == ShippingtoshippingId).Select(u => u.EMail).SingleOrDefault();

                    ////getting the items ordered
                    //var ProductNos = db.OrderDetails.Where(w => w.OrderId == orderId).Select(e => e.Product.ProductNo).ToArray();
                    //var ProductNames = db.OrderDetails.Where(w => w.OrderId == orderId).Select(e => e.Product.ProductName).ToArray();
                    //var Quantities = db.OrderDetails.Where(w => w.OrderId == orderId).Select(e => e.Quantity).ToArray();
                    //string strBodyHeader = "<table style='padding:5px 20px 0px 0px' ><tr style='text-decoration:underline;'><td> Product Number </td><td> Product Name </td><td> Quantity </td></tr>";
                    //string strBodyContent = "";
                    //for (int i = 0; i < ProductNos.Length; i++)
                    //{
                    //    strBodyContent += "<tr><td>" + ProductNos[i] + "</td><td>" + ProductNames[i] + "</td><td align=\"center\">" + Quantities[i] + "</td></tr>";
                    //}
                    //string strBodyFooter = "</table>";
                    //string messageBody = strBodyHeader + strBodyContent + strBodyFooter;


                    if (OrderingToEmail != ShippingToEmail)
                    {
                        if (Session["EmailOrderingCustomer"].ToString() != "False")
                        {
                            //email Ordering person
                            new Emailer().SendEmail(OrderingToEmail, "orders@frontierssi.com", "Frontier Agricultural Sciences Order #" + orderId, "<p style='color: #CC0000;'>Hello,</p>Thank you for shopping with us. You ordered item(s) below.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br />Feel free to contact us if you have any question.<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");
                            new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "Frontier Agricultural Sciences Order #" + orderId, "<p style='color: #CC0000;'>Hello,</p>Thank you for shopping with us. You ordered item(s) below.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br />Feel free to contact us if you have any question.<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");
                        }

                        if (Session["EmailShpToCustomer"].ToString() != "False")
                        {
                            //email ShippingTo person
                            new Emailer().SendEmail(ShippingToEmail, "orders@frontierssi.com", "Frontier Agricultural Sciences Order #" + orderId, "<p style='color: #CC0000;'>Hello,</p>An order has been placed to be shipped to you. The order number is " + orderId + ".<br />You will receive a confirmation email when your order ships.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br />Feel free to contact us if you have any question.<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");
                            new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "Frontier Agricultural Sciences Order #" + orderId, "<p style='color: #CC0000;'>Hello,</p>An order has been placed to be shipped to you. The order number is " + orderId + ".<br />You will receive a confirmation email when your order ships.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br />Feel free to contact us if you have any question.<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");
                        }                        
                    }
                    else
                    {            
                        if (Session["EmailOrderingCustomer"].ToString() == "True" || Session["EmailShpToCustomer"].ToString() == "True")
                        {
                            //email customer(Ordering person is the same as shippingTo person)
                            new Emailer().SendEmail(OrderingToEmail, "orders@frontierssi.com", "Frontier Agricultural Sciences Order #" + orderId, "<p style='color: #CC0000;'>Hello,</p>Thank you for shopping with us. You ordered item(s) below.<br />You will receive a confirmation email when your order ships.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br />Feel free to contact us if you have any question.<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");
                            new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "Frontier Agricultural Sciences Order #" + orderId, "<p style='color: #CC0000;'>Hello,</p>An order has been placed to be shipped to you. The order number is " + orderId + ".<br />You will receive a confirmation email when your order ships.<br /><br /><div style='color: #CC0000;'>Details:</div>" + ItemsOrdered + "<br />Feel free to contact us if you have any question.<br /> http://www.insectrearing.com/contact.html <br /><br /><br />Frontier Agricultural Sciences");
                        }                        
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