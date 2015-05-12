using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontierAg.Models;

namespace FrontierAg.Admin.Categories
{
    public partial class AddCategory : System.Web.UI.Page
    {
        //protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addCategoryForm_InsertItem()
        {
            var item = new FrontierAg.Models.Category();

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                using (ProductContext db = new ProductContext())
                {
                    db.Categories.Add(item);
                    db.SaveChanges();
                }
            }
        }
        
        protected void addCategoryForm_ItemInserted(object sender, FormViewInsertedEventArgs e)  
        {
            Response.Redirect("~/Admin/Categories/Default");
        }
        
        
    }
}