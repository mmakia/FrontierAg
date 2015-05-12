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

namespace FrontierAg.Contacts
{
    public partial class Details : System.Web.UI.Page
    {        
        

		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Select methd to selects a single Contact item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public FrontierAg.Models.Contact GetItem([FriendlyUrlSegmentsAttribute(0)]int? ContactId)
        {
            if (ContactId == null)
            {
                return null;
            }            

            using (_db)
            {
	            return _db.Contacts.Where(m => m.ContactId == ContactId).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }

        //public IQueryable<Order> OpenOrdersList_GetData(Order order)
        //{
        //    if (order != null)
        //    {
        //        using (ProductContext db = new ProductContext())
        //        {
        //           return db.Orders.Where(en => en.o .Include(m => m.Shipping.Contact);
        //            //grab original order
        //            var originalOrder = db.Orders.Find(order.OrderId);
                    
        //            originalOrder

        //            originalOrder.OtherCharge = order.OtherCharge;
        //            originalOrder.Discount = order.Discount;

        //            originalOrder.Total = PreTotal + order.OtherCharge - order.Discount;

        //            originalOrder.Payment = order.Payment;
        //            originalOrder.PaymentDate = order.PaymentDate;
        //            originalOrder.Tracking = order.Tracking;
        //            originalOrder.Comment = order.Comment;
        //            originalOrder.Status = order.Status;
        //            db.SaveChanges();
        //        }
        //    }
        //}
        
    }
}

