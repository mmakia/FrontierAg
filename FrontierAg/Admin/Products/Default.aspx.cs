using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Web.DynamicData;
using System.Data.Entity.Infrastructure;

namespace FrontierAg.Products
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_Init()
        {
            MetaTable table = MetaTable.GetTable(typeof(Product));
            ProductsGrid.SetMetaTable(table);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.Product> ProductsGrid_GetData()
        {
            return _db.Products.Include(m => m.Category).OrderByDescending(m => m.ProductId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ProductsGrid_UpdateItem(int ProductId)
        {
            

                FrontierAg.Models.Product item = null;
                item = _db.Products.Find(ProductId);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", ProductId));
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
        public void ProductsGrid_DeleteItem(int ProductId)
        {
            using (ProductContext db = new ProductContext())
            {
                var item = new Product { ProductId = ProductId };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", ProductId));
                }
            }
        }
        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminPage");
        }  
        
    }
}

