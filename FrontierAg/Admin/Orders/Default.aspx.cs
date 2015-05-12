using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace FrontierAg.Admin.Orders
{
    public partial class Default : System.Web.UI.Page
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
        public IQueryable<Order> OrdersList_GetData() 
        {
            ProductContext db = new ProductContext();
            return db.Orders.Include(m => m.Shipping.Contact);
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
                    //PreTotal = originalOrder.Total - (originalOrder.OtherCharge - originalOrder.Discount);

                    //originalOrder.OtherCharge = order.OtherCharge;
                    //originalOrder.Discount = order.Discount;

                    //originalOrder.Total = PreTotal + order.OtherCharge - order.Discount;

                    //originalOrder.Payment = order.Payment;
                    //originalOrder.PaymentDate = order.PaymentDate;
                    //originalOrder.Tracking = order.Tracking;
                    originalOrder.Comment = order.Comment;
                    originalOrder.Status = order.Status;
                    db.SaveChanges();
                }
            }
        }

        //public IQueryable<OrderDetail> DetailsList_GetData(object sender, EventArgs e)//int? OrderId)
        //{
        //    ProductContext db = new ProductContext();
        //    //return db.OrderDetails;
        //    if (e != null)
        //    {
        //        return null; //db.OrderDetails.Where(m => m.OrderId == e).Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Contact);
        //    }
        //    else
        //     return db.OrderDetails.Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
            
        //}
            
        
    }
}