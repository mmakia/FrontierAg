using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace FrontierAg.Admin.Shippings
{
    public partial class Details : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<FrontierAg.Models.Shipping> ShippingsGrid_GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId, [FriendlyUrlSegmentsAttribute(1)]int? ShippingId)
        {
            if (ContactId == 0 && ShippingId != null)
            {
                return _db.Shippings.Where(n => n.ShippingId == ShippingId);//.Include(m => m.Contact);//////////
            }

            if (ContactId == null)
            {
                return _db.Shippings.Include(m => m.Contact);
            }


            else return _db.Shippings.Where(n => n.ContactId == ContactId && n.isHistory == false).Include(m => m.Contact);//////////
        }
    }
}