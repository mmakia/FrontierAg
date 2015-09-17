using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls;

namespace FrontierAg.Admin.Orders
{
    public partial class CustomOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Order> OpenOrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId)
        {
            ProductContext db = new ProductContext();
            if (OrderId == null)
            {
                return db.Orders.Where(n => (n.Status == Status.InProcess || n.Status == Status.New || n.Status == Status.PartialShipment || n.Status == Status.Shipped) && (n.OrderDate <= System.DateTime.Now)).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);
            }
            else return db.Orders.Where(n => (n.OrderId == OrderId) && (n.OrderDate <= System.DateTime.Now)).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);
        }

        public void OpenOrders_UpdateItem(Order order)
        {
            if (order != null)
            {
                using (ProductContext db = new ProductContext())
                {

                    //grab original order
                    var originalOrder = db.Orders.Find(order.OrderId);
                    //Total fee without  charges
                    //PreTotal = originalOrder.Total;// -(originalOrder.OtherCharge - originalOrder.Discount);

                    //originalOrder.OtherCharge = order.OtherCharge;                                       
                    //originalOrder.Discount = order.Discount;

                    //originalOrder.Total = PreTotal + order.OtherCharge - order.Discount;

                    originalOrder.Payment = order.Payment;
                    //originalOrder.PaymentDate = order.PaymentDate;
                    originalOrder.Tracking = order.Tracking;
                    originalOrder.Comment = order.Comment;
                    //originalOrder.Status = order.Status;
                    db.SaveChanges();
                }
            }

        }

        protected void Unnamed_Click0(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int myOrderId = Int32.Parse(yourValue);
            using (ProductContext db = new ProductContext())
            {
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.SType == SType.Ordering).Select(en => en.ShippingId).FirstOrDefault();

                Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Details", 0, myShippingId));

            }
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int myOrderId = Int32.Parse(yourValue);
            using (ProductContext db = new ProductContext())
            {
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.SType == SType.Billing).Select(en => en.ShippingId).FirstOrDefault();

                Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Details", 0, myShippingId));

            }
        }
    }
}