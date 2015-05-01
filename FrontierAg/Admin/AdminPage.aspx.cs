﻿using System;
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
            Response.Redirect("~/Admin/Contact.aspx");
        }

        protected void ShippingsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Shipping.aspx");
        }

        
        protected void CategoriesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Category.aspx");
        }

        protected void ProductsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Products/");
        }

        

        protected void OpenOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Orders/OpenOrder");
        }

        

        

        protected void AllOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Orders");
        }
    }
}