using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using FrontierAg.Models;

namespace FrontierAg.Prices
{
    public partial class Delete : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Price item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(int PriceId)
        {
            using (_db)
            {
                var item = _db.Prices.Find(PriceId);

                if (item != null)
                {
                    _db.Prices.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Price item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public FrontierAg.Models.Price GetItem([FriendlyUrlSegmentsAttribute(0)]int? PriceId)
        {
            if (PriceId == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Prices.Where(m => m.PriceId == PriceId).Include(m => m.Product).FirstOrDefault();
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

