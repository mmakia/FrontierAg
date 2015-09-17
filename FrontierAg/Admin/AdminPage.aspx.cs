using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ReturnUrlCreateOrdering"] = "";
            Session["ReturnUrlEditOrdering"] = "";
            Session["ReturnUrlCreateContact"] = "";
            Session["ReturnUrlEditContact"] = "";
            Session["ReturnUrlCreateShipping"] = "";
            Session["ReturnUrlEditShipping"] = "";
            Session["ReturnUrlCreateBilling"] = "";
            Session["ReturnUrlEditBilling"] = "";
        }

        protected void ContactsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Contacts/Default");
        }
        
        protected void CategoriesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Categories/Default");
        }

        protected void ProductsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Products/Default");
        }       

        
        protected void AllOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Orders/Default");
        }

        protected void AllShipments_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Shipments/Default");
        }

        protected void Emails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Emails/Default");
        }

        protected void ToProcessOrdersBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Orders/ToProcess");
        }

        protected void Raw_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/raws/Default");
        }
    }
}