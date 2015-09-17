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

namespace FrontierAg.Admin.Raws
{
    public partial class Delete : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Raw item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(int RawId)
        {
            using (_db)
            {
                var item = _db.Raws.Find(RawId);

                if (item != null)
                {
                    _db.Raws.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Raw item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public FrontierAg.Models.Raw GetItem([FriendlyUrlSegmentsAttribute(0)]int? RawId)
        {
            if (RawId == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Raws.Where(m => m.RawId == RawId).FirstOrDefault();
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

