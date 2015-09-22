using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System.Configuration;

namespace FrontierAg.Admin.Raws
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //to force browser to reload when using back button inorder to display updated info on page
            if (!IsPostBack)
            {
                Response.Buffer = true;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "no-cache");
                Response.Expires = -1441;
               
            }
        }

        // Model binding method to get List of Raw entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Raw> GetData([FriendlyUrlSegmentsAttribute(0)]string searchstring)
        {
            if(searchstring != null)
            {
                return _db.Raws.Where(u => u.Product.ProductName.Contains(searchstring));
            }
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

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

            string yourValue = Server.HtmlEncode(TextBox1.Text.Trim());

            if (yourValue != "")
            {
                Response.Redirect(FriendlyUrl.Href("~/Admin/Raws/Default/", yourValue));
            }

            Response.Redirect(FriendlyUrl.Href("~/Admin/Raws/Default/"));
        }                     
    }
}

