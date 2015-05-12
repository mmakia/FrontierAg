using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init()
        {
            MetaTable table = MetaTable.GetTable(typeof(Product));
            addProductForm.SetMetaTable(table);
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
                    item.DateCreated = DateTime.Now;
                    db.Products.Add(item);
                    db.SaveChanges();
                }
            }
        }

        protected void addProductForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/Products/Default");
        }        
    }
}