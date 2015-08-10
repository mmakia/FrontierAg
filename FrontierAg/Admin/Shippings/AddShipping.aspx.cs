using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
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

        public void addShippingForm_InsertItem([FriendlyUrlSegmentsAttribute(0)]int ContactId)
        {
            var item = new FrontierAg.Models.Shipping();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                using (FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext())
                {
                    item.ContactId = ContactId;
                    item.DateCreated = System.DateTime.Now;
                    db.Shippings.Add(item);
                    db.SaveChanges();
                }
            }

            if ((string)(Session["ReturnUrlCreateOrdering"]) != "")//if exist
            {
                Response.Redirect((string)(Session["ReturnUrlCreateOrdering"]) + "/" + item.ShippingId);
            }
            else if ((string)(Session["ReturnUrlCreateShipping"]) != "")//if exist
            {
                Response.Redirect((string)(Session["ReturnUrlCreateShipping"]) + "/" + item.ShippingId);
            }
            else if ((string)(Session["ReturnUrlCreateBilling"]) != "")//if exist
            {
                Response.Redirect((string)(Session["ReturnUrlCreateBilling"]) + "/" + item.ShippingId);
            }
            else
            {
                Response.Redirect("~/Admin/Contacts/Default");
            }
        }

        protected void addShippingForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {

            //Response.Redirect("~/Admin/Contacts/Default");
        }
        
    }
}