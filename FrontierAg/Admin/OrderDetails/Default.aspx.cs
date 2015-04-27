using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;


using Microsoft.AspNet.FriendlyUrls.ModelBinding;namespace FrontierAg.OrderDetails
{
    public partial class Default : System.Web.UI.Page
    {
        
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of OrderDetail entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.OrderDetail> GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId)
        {
            
            if (OrderId != null)
            {
                return _db.OrderDetails.Where(m => m.OrderId == OrderId).Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Contact); 
            }

            else return _db.OrderDetails.Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Contact);
            
        }
    }
}

