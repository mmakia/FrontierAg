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
    public partial class Default : System.Web.UI.Page
    {
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

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.Shipment> ShipmentList_GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId)
        {
            ProductContext db = new ProductContext();
            if (OrderId != null)
            {                
                return db.Shipments.Where(en => en.OrderId == OrderId);//.Include(en => en.OrderShippings.Select(m => m.Shipping))
            }
            else return db.Shipments;
        }

        // The id parameter name should match the DataKeyNames value set on the control
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
                    originalShipment.Total = originalShipment.Total - originalShipment.ShipCharge + shipment.ShipCharge - originalShipment.PFee + shipment.PFee;
                    originalShipment.PFee = shipment.PFee;
                    originalShipment.ShipCharge = shipment.ShipCharge;
                    originalShipment.Comment = shipment.Comment;
                    originalShipment.DateCreated = System.DateTime.Now;                                
                    db.SaveChanges();

                    new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Shipment ", "There is a new Shipment, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Shipments/Default ");
                    new Emailer().SendEmail("rwright@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Shipment ", "There is a new Shipment, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Shipments/Default ");
                }
            }
        }
    }
}