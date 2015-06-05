using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;

namespace FrontierAg.Contacts
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Contact entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Contact> GetData([FriendlyUrlSegmentsAttribute(0)]String SearchString)
        {            
            if (!String.IsNullOrEmpty(SearchString))
            {
                return _db.Contacts.Where(s => s.Company.Contains(SearchString) || s.LName.Contains(SearchString) || s.FName.Contains(SearchString));
            }
            return _db.Contacts;
        }

        protected void BackBtn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminPage");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string yourValue = Server.HtmlEncode(TextBox1.Text);

            if (yourValue != "")
            {
                Response.Redirect(FriendlyUrl.Href("~/Admin/Contacts/Default/", yourValue));
            }

            Response.Redirect(FriendlyUrl.Href("~/Admin/Contacts/Default/"));
        }
    }
}

