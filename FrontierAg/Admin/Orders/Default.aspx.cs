using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Web.ModelBinding;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Microsoft.AspNet.FriendlyUrls;

namespace FrontierAg.Admin.Orders
{
    public partial class Default : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorLbl.Text = "";
            }
            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Order> OrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId, [Control] Status? Status) 
        {                    
            FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

            if (ContactId != null)
            {                
                var query = _db.Orders.Where(en => en.ContactId == ContactId); //_db.Orders.Include(m => m.OrderShippings.Select(en => en.Shipping)).Where(en => en.ContactId == ContactId);                                             

                if (Status != null)
                {
                    query = query.Where(en => en.Status == Status);
                }
                return query.OrderByDescending(en => en.OrderDate);
            }
            else
                if (Status != null)
                {
                    var query = _db.Orders.Include(n => n.OrderShippings.Select(en => en.Shipping.Contact));
                    return query = query.Where(en => en.Status == Status).OrderByDescending(en => en.OrderDate);
                }

            return _db.Orders.Include(n => n.OrderShippings.Select(en => en.Shipping.Contact)).OrderByDescending(en => en.OrderDate);
        }



        public void OpenOrders_UpdateItem(Order order)
        {
            if (order != null)
            {
                using (ProductContext db = new ProductContext())
                {

                    //grab original order
                    var originalOrder = db.Orders.Find(order.OrderId);
                    //bool HasShipments = db.Shipments.Any(en => en.OrderId == order.OrderId);
                    
                    if (order.Status == FrontierAg.Models.Status.Cancelled && originalOrder.Status != FrontierAg.Models.Status.New)
                    {
                        ErrorLbl.Text = "**** This Order can not be cancelled directly, Please Cancel each shipment related to this order first, then this order will be cancelled Automatically ****";
                        return;
                    }
                    originalOrder.Comment = order.Comment;
                    originalOrder.Status = order.Status;

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