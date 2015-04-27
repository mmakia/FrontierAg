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


namespace FrontierAg.Orders
{
    public partial class Details : System.Web.UI.Page
    {
        //protected ProductContext _db = new ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

         //This is the Select methd to selects a single Order item with the id
         //USAGE: <asp:FormView SelectMethod="GetItem">
        //public FrontierAg.Models.Order GetItem([FriendlyUrlSegmentsAttribute(0)]int? OrderId)
        //{
        //    if (OrderId == null)
        //    {
        //        return null;
        //    }

        //    using (ProductContext _db = new ProductContext())
        //    {
        //        return _db.Orders.Where(m => m.OrderId == OrderId).Include(m => m.Contact).FirstOrDefault();
        //    }
        //}

        public IQueryable<OrderDetail> GetOrderDetail()//[FriendlyUrlSegmentsAttribute(0)]int? OrderId2)
        {
            //if (OrderId2 == null)
            //{
            //    return null;
            //}

            using (ProductContext _db = new ProductContext())
            {
                return _db.OrderDetails;//.Where(m => m.OrderId == OrderId2);
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

