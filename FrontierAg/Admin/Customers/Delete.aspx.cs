﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using FrontierAg.Models;

namespace FrontierAg.Admin.Customers
{
    public partial class Delete : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Customer item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(int CustomerId)
        {
            using (_db)
            {
                var item = _db.Customers.Find(CustomerId);

                if (item != null)
                {
                    _db.Customers.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Customer item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public FrontierAg.Models.Customer GetItem([FriendlyUrlSegmentsAttribute(0)]int? CustomerId)
        {
            if (CustomerId == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Customers.Where(m => m.CustomerId == CustomerId).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}
