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

namespace FrontierAg.Checkout
{
    public partial class CheckoutStart : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        // Model binding method to get List of Contact entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Contact> GetContacts2([FriendlyUrlSegmentsAttribute(0)] int? ContactId)
        {
            if (ContactId == null)
            {
                return null;
            }
            else
            {
                return _db.Contacts.Where(en => en.Type == CType.Customer);
            }
        }

        

        public IQueryable<FrontierAg.Models.Contact> GetContacts()
        {
            return _db.Contacts.Where(en => en.Type == CType.Customer);
        }


        public IQueryable<FrontierAg.Models.Shipping> GetData([FriendlyUrlSegmentsAttribute(1)] int? ContactId)
        {            

            if (ContactId == null)
            {
                return null;
            }

            return _db.Shippings.Where(n => n.ContactId == ContactId);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout/ShoppingCart");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;
            IList<string> segments = Request.GetFriendlyUrlSegments();

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/" , int.Parse(segments[0]) , yourValue));
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;
            IList<string> segments = Request.GetFriendlyUrlSegments();

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutReview/", int.Parse(segments[0]), int.Parse(segments[1]), yourValue));
        }       
          
    }
}

