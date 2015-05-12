using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Shippings
{
    public partial class AddShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init()
        {
            MetaTable table = MetaTable.GetTable(typeof(Shipping));
            addShippingForm.SetMetaTable(table);
        }

        public void addShippingForm_InsertItem()
        {
            var item = new FrontierAg.Models.Shipping();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                using (FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext())
                {
                    db.Shippings.Add(item);
                    db.SaveChanges();
                }
            }
        }

        protected void addShippingForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/Contacts/Default");
        }
        
    }
}