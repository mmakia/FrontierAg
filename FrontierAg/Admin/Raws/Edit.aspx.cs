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
namespace FrontierAg.Admin.Raws
{
    public partial class Edit : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Update methd to update the selected Raw item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(int  RawId)
        {
            using (_db)
            {
                var item = _db.Raws.Find(RawId);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", RawId));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }
        }

        // This is the Select method to selects a single Raw item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public FrontierAg.Models.Raw GetItem([FriendlyUrlSegmentsAttribute(0)]int? RawId)
        {
            if (RawId == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Raws.Find(RawId);
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
