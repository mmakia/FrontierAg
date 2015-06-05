using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Shipments
{
    public partial class ShipmentDetail : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext();

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

        public IQueryable<FrontierAg.Models.Shipment> ShipmentList_GetData([FriendlyUrlSegmentsAttribute(0)]int? ShipmentId)
        {
            if (ShipmentId != null)
            {
                //ProductContext db = new ProductContext();
                return db.Shipments.Where(en => en.ShipmentId == ShipmentId);
            }
            else return null;
        }

        public void ShipmentList_UpdateItem(Shipment shipment)
        {
            if (shipment != null)
            {
                using (ProductContext db = new ProductContext())
                {

                    //grab original order
                    var originalShipment = db.Shipments.Find(shipment.ShipmentId);

                    //originalShipment.OrderId = shipment.OrderId;
                    originalShipment.Tracking = shipment.Tracking;
                    originalShipment.Total = originalShipment.Total - originalShipment.ShipCharge + shipment.ShipCharge;
                    originalShipment.ShipCharge = shipment.ShipCharge;
                    originalShipment.Comment = shipment.Comment;
                    originalShipment.DateCreated = System.DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public IQueryable<FrontierAg.Models.Shipping> ShippingsGrid_GetData([FriendlyUrlSegmentsAttribute(0)]int? ShipmentId)//[FriendlyUrlSegmentsAttribute(0)]int? ContactId, [FriendlyUrlSegmentsAttribute(1)]int? ShippingId)
        {
            //if (ContactId == 0 && ShippingId != null)
            //{
            //    return _db.Shippings.Where(n => n.ShippingId == ShippingId);//.Include(m => m.Contact);//////////
            //}

            if (ShipmentId != null)
            {
                var myShipping = (from my in db.Shipments
                                  where my.ShipmentId == ShipmentId 
                                     select my.Shipping);
                
                return myShipping;// _db.OrderShippings.Include(m => m.Contact);
            }


            else return null;// _db.OrderShippings.Where(n => n.OrderId == OrderId && n.Shipping.isShipping == true).Select(en => en.Shipping);//.Include(m => m.Contact);//////////
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.ShipmentDetail> ShipmentDetailsList_GetData([FriendlyUrlSegmentsAttribute(0)]int? ShipmentId)
        {
            if (ShipmentId != null)
            {
                ProductContext db = new ProductContext();
                return db.ShipmentDetails.Where(en => en.ShipmentId == ShipmentId);
            }
            else return null;            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ShipmentDetailsList_UpdateItem(int id)
        {
            FrontierAg.Models.ShipmentDetail item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }


    }
}