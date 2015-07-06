using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Shippings
{
    public partial class Edit : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void Unnamed_UpdateItem(Shipping newShipping)
        {
            //SType temp1;
            //DateTime temp2;

            using (_db)
            {
                
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                var originalItem = _db.Shippings.Find(newShipping.ShippingId);

                if (originalItem == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", newShipping.ShippingId));
                    return;
                }

                //temp1 = (SType)originalItem.SType;
                //temp2 = originalItem.DateCreated;             

                //_db.SaveChanges();
                TryUpdateModel(originalItem);
                if (ModelState.IsValid)
                {
                    //originalItem.SType = temp1;
                    //originalItem.DateCreated = temp2;

                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    _db.SaveChanges();
                    if ((string)(Session["ReturnUrlEditShipping"]) != "")
                    {
                        Response.Redirect((string)(Session["ReturnUrlEditShipping"]));
                    }

                    else if ((string)(Session["ReturnUrlEditBilling"]) != "")
                    {
                        Response.Redirect((string)(Session["ReturnUrlEditBilling"]));
                    }

                    else
                    {
                        Response.Redirect("~/Admin/Shippings/Default");
                    }

                }
            }
        }

        public FrontierAg.Models.Shipping GetItem([FriendlyUrlSegmentsAttribute(0)]int? ShippingId)
        {
            if (ShippingId == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Shippings.Find(ShippingId);
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}