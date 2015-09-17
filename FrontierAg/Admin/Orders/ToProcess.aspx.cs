using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.ModelBinding;

namespace FrontierAg.Admin.Orders
{
    public partial class ToProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable GetCategories()
        {
            var _db = new FrontierAg.Models.ProductContext();
            IQueryable query = _db.Categories;
            return query;
        }

        protected void GoToOrdersBtn_Click(object sender, EventArgs e)
        {
            
            //List<ListItem> selectedCategories = new List<ListItem>();
            //foreach (ListItem item in CheckBoxSelectCategory.Items)
            //    if (item.Selected) selectedCategories.Add(item);

            //List<ListItem> selectedStatus = new List<ListItem>();
            //foreach (ListItem item in CheckBoxSelectCategory.Items)
            //    if (item.Selected) selectedStatus.Add(item);

            Response.Redirect(FriendlyUrl.Href("~/Admin/Orders/ToProcess"));
        }


        //CheckBoxSelectStatus
        public IQueryable<Order> OrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId, [Control] Status? Status2, [Control] string[] CheckBoxSelectCategory2)


        {
            ProductContext db = new ProductContext();
            //var y = Status2[0]?;
            //var x = Status2[1];
            //var s = Status2[3];
            //var z = Status2[4];

            if (OrderId == null)
            {
                if (Status2 != null)

                    return db.Orders.Where(n => (n.OrderId == 150)).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);//extra line
                else return db.Orders.Where(n => (n.OrderDate <= System.DateTime.Now)).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);
                
            }
            else return db.Orders.Where(n => (n.OrderId == OrderId) && (n.OrderDate <= System.DateTime.Now)).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);
        }

        public void Orders_UpdateItem(Order order)
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