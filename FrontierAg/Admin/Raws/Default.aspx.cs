using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Data.Entity.Infrastructure;

namespace FrontierAg.Admin.Raws
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Raw entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Raw> GetData3()
        {
            return _db.Raws;
        }
        //xx
        
        // The id parameter name should match the DataKeyNames value set on the control
        public void RawsGrid_UpdateItem(int RawId)
        {
            FrontierAg.Models.Raw item = null;
            item = _db.Raws.Find(RawId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", RawId));
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
        public void RawsGrid_DeleteItem(int RawId)
        {
            using (ProductContext db = new ProductContext())
            {
                var item = new Raw { RawId = RawId };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", RawId));
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminPage");
        }


        //xx
    }
}

