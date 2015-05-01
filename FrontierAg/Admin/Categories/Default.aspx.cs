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

namespace FrontierAg.Admin.Categories
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
        public IQueryable<FrontierAg.Models.Category> CategoriesList_GetData()
        {
            
            return _db.Categories;
        }

        public void CategoriesList_UpdateData(int CategoryId)
        {
            FrontierAg.Models.Category item = null;
            item = _db.Categories.Find(CategoryId);
                
                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", CategoryId));
                    return;
                }               

                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                   _db.SaveChanges();

                }
            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesList_DeleteItem(int CategoryId)
        {

            var item2 = new Category { CategoryId = CategoryId };
            _db.Entry(item2).State = EntityState.Deleted;
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("",
                  String.Format("Item with id {0} no longer exists in the database.", CategoryId));
            }


        }

        protected void backBtn_Click(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/");
        }
    }
}