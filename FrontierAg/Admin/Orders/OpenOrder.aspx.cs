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
    public partial class OpenOrder : System.Web.UI.Page
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
        public IQueryable<Order> OpenOrdersList_GetData()
        {
            ProductContext db = new ProductContext();
            return db.Orders.Where(n => n.Status == Status.Processing || n.Status == Status.Other || n.Status == Status.Shipped).Include(en => en.Shipping).Include(m => m.Shipping.Contact);
        }

        public void OpenOrders_UpdateItem(int OrderId)
        {
            using (ProductContext db = new ProductContext())
            {
                FrontierAg.Models.Order item = db.Orders.Find(OrderId);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", OrderId));
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