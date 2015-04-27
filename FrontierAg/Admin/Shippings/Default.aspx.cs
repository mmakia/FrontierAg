using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;

namespace FrontierAg.Shippings
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Shipping entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Shipping> GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId)
        {

            if (ContactId != null)
            {
                return _db.Shippings.Where(n => n.ContactId == ContactId).Include(m => m.Contact);
            }

            else return _db.Shippings.Include(m => m.Contact);
        }
    }
}

