using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;

namespace FrontierAg.Admin.PackCharges
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
        public IQueryable<FrontierAg.Models.PackCharge> PackChargesGrid_GetData([FriendlyUrlSegments(0)] int? ProductId)
        {
            if (ProductId != null)
                return _db.PackCharges.Where(en => en.ProductId == ProductId).Include(m => m.Product);
            else return _db.PackCharges;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PackChargesGrid_UpdateItem(int PackChargeId)
        {
            FrontierAg.Models.PackCharge item = null;
            item = _db.PackCharges.Find(PackChargeId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", PackChargeId));
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
        public void PackChargesGrid_DeleteItem(int PackChargeId)
        {
            using (ProductContext db = new ProductContext())
            {
                var item = new PackCharge { PackChargeId = PackChargeId };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", PackChargeId));
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Products/");
        }
    }
}