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
    }
}