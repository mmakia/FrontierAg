using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Web.ModelBinding;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;

namespace FrontierAg.Admin.Prices
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }        

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.Price> PricesGrid_GetData([FriendlyUrlSegments(0)] int? ProductId)
        {
            if (ProductId != null)
                return _db.Prices.Where(en => en.ProductId == ProductId).Include(m => m.Product);
            else return _db.Prices;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PricesGrid_UpdateItem(int PriceId)
        {            
            FrontierAg.Models.Price item = null;
            item = _db.Prices.Find(PriceId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", PriceId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                _db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PricesGrid_DeleteItem(int PriceId)
        {
            using (ProductContext db = new ProductContext())
            {
                var item = new Price { PriceId = PriceId };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", PriceId));
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Products/");
        }
        
    }
}

