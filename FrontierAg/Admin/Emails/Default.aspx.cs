using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Data.Entity.Infrastructure;

namespace FrontierAg.Admin.Emails
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Email entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Email> GetData()
        {
            return _db.Emails;
        }

        

        // The id parameter name should match the DataKeyNames value set on the control
        public void EmailsGrid_UpdateItem(int EmailId)
        {
            FrontierAg.Models.Email item = null;            
            item = _db.Emails.Find(EmailId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", EmailId));
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
        public void EmailsGrid_DeleteItem(int EmailId)
        {
            using (ProductContext db = new ProductContext())
            {
                var item = new Email { EmailId = EmailId };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", EmailId));
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminPage");
        }  
    }
}

