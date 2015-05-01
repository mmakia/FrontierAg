using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure; 
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System.Web.ModelBinding;

namespace FrontierAg.Admin.OrderDetails
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<OrderDetail> OrderDetailsList_GetData([QueryString] int? OrderId)
        {
            ProductContext db = new ProductContext();            
            //return db.OrderDetails;
            if (OrderId != null)
            {
                return db.OrderDetails.Where(m => m.OrderId == OrderId).Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
            }

            else return db.OrderDetails.Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
        }

        public void OrderDetails_UpdateItem(int OrderDetailId)
        {
            using(ProductContext db = new ProductContext())
            {
                FrontierAg.Models.OrderDetail item = db.OrderDetails.Find(OrderDetailId);
                
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", OrderDetailId));
                    return;
                }

                //item.Payment = 
                //    TextBox priceTextBox = new TextBox();
                //    priceTextBox = (TextBox)CartList.Rows[i].FindControl("PriceBx");
                //    cartUpdates[i].PriceBx = Convert.ToDecimal(priceTextBox.Text.ToString());

                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    db.SaveChanges();

                }
            }
        }

        
            
        
    }
}