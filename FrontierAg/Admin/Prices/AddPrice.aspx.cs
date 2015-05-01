using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Prices
{
    public partial class AddPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addPriceForm_InsertItem()
        {
            var item = new FrontierAg.Models.Price();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                using (FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext())
                {
                    db.Prices.Add(item);
                    db.SaveChanges();
                }
            }
        }

        protected void addPriceForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/Prices");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Prices");
        }
    }
}