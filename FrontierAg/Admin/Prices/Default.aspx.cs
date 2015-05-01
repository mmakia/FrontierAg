using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Web.ModelBinding;

namespace FrontierAg.Prices
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
        public IQueryable<FrontierAg.Models.Price> PricesGrid_GetData([QueryString] int ProductId)
        {
            return _db.Prices.Where(en => en.ProductId == ProductId).Include(m => m.Product);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PricesGrid_UpdateItem(int id)
        {
            FrontierAg.Models.Price item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                _db.SaveChanges();
            }
        }
    }
}

