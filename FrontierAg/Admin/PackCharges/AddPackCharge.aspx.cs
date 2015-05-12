using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.PackCharges
{
    public partial class AddPackCharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //for drop down list
        protected void Page_Init()
        {
            MetaTable table = MetaTable.GetTable(typeof(PackCharge));
            addPackChargeForm.SetMetaTable(table);
        }

        public void addPackChargeForm_InsertItem()
        {
            var item = new FrontierAg.Models.PackCharge();            
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                using (FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext())
                {
                    db.PackCharges.Add(item);
                    db.SaveChanges();
                }
            }
        }

        protected void addPackChargeForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Admin/PackCharges/Default");
        }
    }
}