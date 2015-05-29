using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Microsoft.AspNet.FriendlyUrls;
using System.Web.ModelBinding;
using System.Web.SessionState;

namespace FrontierAg.Checkout
{
    public partial class CheckoutStart : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        //In the method: Session["BackgroundColor"] = ColorSelector.SelectedValue;

        public IQueryable<FrontierAg.Models.Contact> GetContacts([FriendlyUrlSegmentsAttribute(3)]String searchString)
        {
            if(searchString != null)
            {
                return _db.Contacts.Where(en => en.Type == CType.Customer && (en.Company.Contains(searchString) || en.LName.Contains(searchString) || en.FName.Contains(searchString)));                
            }

            else 
            {
                return _db.Contacts.Where(en => en.Type == CType.Customer);
            }            
        }


        public IQueryable<FrontierAg.Models.Shipping> GetData2([FriendlyUrlSegmentsAttribute(0)] int? ContactId)
        {
            //if (Session["myContactId"] == null)
            if (ContactId == null || ContactId == 0)
            {
                return null;
            }
            //int x = Convert.ToInt32(Session["myContactId"]);
            return _db.Shippings.Where(n => n.ContactId == ContactId && n.SType == SType.Shipping && n.isHistory == false);//_db.Shippings.Where(n => n.ContactId == ContactId && n.SType == SType.Shipping && n.isHistory == false);
        }

        public IQueryable<FrontierAg.Models.Shipping> GetData3([FriendlyUrlSegmentsAttribute(0)] int? ContactId, [FriendlyUrlSegmentsAttribute(1)] int? ShippingId)
        {
            //if (Session["Shipping"] == null)
            if (ContactId == null || ShippingId == null || ContactId == 0 || ShippingId == 0)
            {
                return null;
            }
            //int y = Convert.ToInt32(Session["myContactId"]);
            return _db.Shippings.Where(n => n.ContactId == ContactId && n.SType == SType.Billing && n.isHistory == false);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout/ShoppingCart");
        }

        protected void Unnamed_Click2(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue2 = btn.CommandArgument;
            //Session["Shipping"] = yourValue2;
            //Response.Redirect(Request.RawUrl);
            IList<string> segments = Request.GetFriendlyUrlSegments();

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/", int.Parse(segments[0]), yourValue2));
        }

        protected void Unnamed_Click3(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue3 = btn.CommandArgument;
            //Session["Billing"] = yourValue3;
            IList<string> segments = Request.GetFriendlyUrlSegments();
            //Int32 myContactId = Convert.ToInt32(Session["myContactId"]);
            //Int32 Shipping = Convert.ToInt32(Session["Shipping"]);
            //Int32 Billing = Convert.ToInt32(Session["Billing"]);

            //Session["myContactId"] = null;
            //Session["Shipping"] = null;
            //Session["Billing"] = null; 

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutReview/", int.Parse(segments[0]), int.Parse(segments[1]), yourValue3));
        }
        
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string yourValue = Server.HtmlEncode(TextBox1.Text);

            if (yourValue != "")
            {
                Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/", 0, 0,0, yourValue));
            }

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/"));
        }
    }
}

