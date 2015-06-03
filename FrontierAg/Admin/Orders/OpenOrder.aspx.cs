using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;

namespace FrontierAg.Admin.Orders
{
    public partial class OpenOrder : System.Web.UI.Page
    {
        Decimal PreTotal;
        
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Order> OpenOrdersList_GetData()
        {
            ProductContext db = new ProductContext();
            return db.Orders.Where(n => n.Status == Status.Processing || n.Status == Status.Billed || n.Status == Status.New || n.Status == Status.PartialShipment || n.Status == Status.Shipped).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact));
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
                    PreTotal = originalOrder.Total - (originalOrder.OtherCharge - originalOrder.Discount);

                    originalOrder.OtherCharge = order.OtherCharge;                                       
                    originalOrder.Discount = order.Discount;

                    originalOrder.Total = PreTotal + order.OtherCharge - order.Discount;

                    originalOrder.Payment = order.Payment;
                    originalOrder.PaymentDate = order.PaymentDate;
                    originalOrder.Tracking = order.Tracking;
                    originalOrder.Comment = order.Comment;
                    originalOrder.Status = order.Status;
                    db.SaveChanges();
                }
            }
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int myOrderId = Int32.Parse(yourValue);
            using (ProductContext db = new ProductContext())
            {
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.Shipping.SType == SType.Billing).Select(en => en.ShippingId).FirstOrDefault();

                Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Default",0, myShippingId));

            }
        }
        
        
    }
}