using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addProductForm_InsertItem()
        {
            var item = new FrontierAg.Models.Product();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                using (FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext())
                {
                    db.Products.Add(item);
                    db.SaveChanges();
                }
            }
        }

        protected void addProductForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/Products");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Products");
        }
    }
}