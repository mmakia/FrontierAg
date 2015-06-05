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
        public IQueryable<Order> OrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId, [Control] Status? Status) 
        {
            
             
            //old code
            //ProductContext db = new ProductContext();
            //var query = db.Orders.Include(n => n.OrderShippings.Select(en => en.Shipping.Contact));

            //if (Status != null)
            //{
            //    query = query.Where(en => en.Status == Status);
            //}
            //return query;
            FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

            if (ContactId != null)
            {                
                var query = _db.Orders.Where(en => en.ContactId == ContactId); //_db.Orders.Include(m => m.OrderShippings.Select(en => en.Shipping)).Where(en => en.ContactId == ContactId);                                             

                if (Status != null)
                {
                    query = query.Where(en => en.Status == Status);
                }
                return query;
            }
            else
                if (Status != null)
                {
                    var query = _db.Orders.Include(n => n.OrderShippings.Select(en => en.Shipping.Contact));
                    return query = query.Where(en => en.Status == Status);
                }            

            return _db.Orders.Include(n => n.OrderShippings.Select(en => en.Shipping.Contact));
        }



        public void OpenOrders_UpdateItem(Order order)
        {
            if (order != null)
            {
                using (ProductContext db = new ProductContext())
                {

                    //grab original order
                    var originalOrder = db.Orders.Find(order.OrderId);
                    
                    originalOrder.Comment = order.Comment;
                    originalOrder.Status = order.Status;
                    db.SaveChanges();
                }
            }
        }    
            
        
    }
}