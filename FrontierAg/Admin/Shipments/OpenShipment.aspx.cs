using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Shipments
{
    public partial class OpenShipment : System.Web.UI.Page
    {       
        bool isRemainingZero = true;
        bool isAllPaid = true;
        bool isAllCancelled = true;
        string isEmailInternalUsers = ConfigurationManager.AppSettings["EmailInternalUsers"];

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
                return db.Shipments.Where(en => en.OrderId == OrderId && (en.Action == FrontierAg.Models.Action.New || en.Action == FrontierAg.Models.Action.ToInvoice || en.Action == FrontierAg.Models.Action.Invoiced)).OrderByDescending(en => en.DateCreated);//.Include(en => en.OrderShippings.Select(m => m.Shipping))
            }
            else return db.Shipments.Where(en => en.Action == FrontierAg.Models.Action.New || en.Action == FrontierAg.Models.Action.ToInvoice || en.Action == FrontierAg.Models.Action.Invoiced).OrderByDescending(en => en.DateCreated);//.Include(en => en.OrderShippings.Select(m => m.Shipping));
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
                    //var myOrder = db.Orders.Find(shipment.OrderId);

                    //originalShipment.OrderId = shipment.OrderId;
                    originalShipment.Tracking = shipment.Tracking;
                    originalShipment.Total = originalShipment.Total - originalShipment.ShipCharge + shipment.ShipCharge - originalShipment.PFee + shipment.PFee - originalShipment.PCharges + shipment.PCharges - originalShipment.OtherCharges + shipment.OtherCharges;
                    originalShipment.PCharges = shipment.PCharges;
                    originalShipment.PFee = shipment.PFee;
                    originalShipment.ShipCharge = shipment.ShipCharge;
                    originalShipment.OtherCharges = shipment.OtherCharges;
                    originalShipment.Comment = shipment.Comment;

                    if (originalShipment.Action != FrontierAg.Models.Action.ToInvoice && shipment.Action == FrontierAg.Models.Action.ToInvoice)
                    {
                        originalShipment.ReadyDate2 = System.DateTime.Now;
                    }

                    originalShipment.Action = shipment.Action;
                    originalShipment.DateCreated = System.DateTime.Now;


                    //check if all paid and remaming == zero then order status is closed
                    if (shipment.Action == FrontierAg.Models.Action.Paid)
                    {
                        //check if all OrderDetails have remaining zero
                        var myorder1 = db.Orders.Where(e => e.OrderId == originalShipment.OrderId).SingleOrDefault();
                        var allOrderDetails = db.OrderDetails.Where(e => e.OrderId == originalShipment.OrderId);                        
                        foreach (var b in allOrderDetails){
                            if (b.Quantity != b.QtyCancelled + b.QtyShipped)
                            {
                                isRemainingZero = false;
                            }
                        }                        
                        //Check if All shipments are Paid for
                        var allShipments = db.Shipments.Where(r => r.OrderId == originalShipment.OrderId);
                        foreach (var a in allShipments)
                        {
                            if (a.Action != FrontierAg.Models.Action.Paid)
                            {
                                isAllPaid = false;
                            }
                        }

                        if (isRemainingZero && isAllPaid)
                        {
                            myorder1.Status = Status.Closed;
                        }
                    }


                    //check if all Cancelled and remaming == zero then order status is Cancelled/////////
                    if (shipment.Action == FrontierAg.Models.Action.Cancel)
                    {
                        //check if all OrderDetails have remaining zero
                        var myorder1 = db.Orders.Where(e => e.OrderId == originalShipment.OrderId).SingleOrDefault();
                        var allOrderDetails = db.OrderDetails.Where(e => e.OrderId == originalShipment.OrderId);
                        foreach (var b in allOrderDetails)
                        {
                            if (b.Quantity != b.QtyCancelled + b.QtyShipped)
                            {
                                isRemainingZero = false;
                            }
                        }
                        //Check if All shipments are cancelled for
                        var allShipments = db.Shipments.Where(r => r.OrderId == originalShipment.OrderId);
                        foreach (var a in allShipments)
                        {
                            if (a.Action != FrontierAg.Models.Action.Cancel)
                            {
                                isAllCancelled = false;
                            }
                        }

                        if (isRemainingZero && isAllCancelled)
                        {
                            myorder1.Status = Status.Cancelled;
                        }
                    }
                    

                    db.SaveChanges();

                    //Email Billing dept
                    if (shipment.Action == FrontierAg.Models.Action.ToInvoice && isEmailInternalUsers == "1"){
                        var allEmails = db.Emails.Where(r => r.isForShipment == true);
                        foreach (var a in allEmails)
                        {
                            new Emailer().SendEmail(a.EmailAddress, "orders@frontierssi.com", "FrontierAg New Shipment for Order Id " + originalShipment.OrderId, "There is a new Shipment, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Shipments/OpenShipment ");
                        }

                        //new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Shipment for Order Id " + originalShipment.OrderId, "There is a new Shipment, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Shipments/OpenShipment ");
                        //new Emailer().SendEmail("rwright@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Shipment for Order Id " + originalShipment.OrderId, "There is a new Shipment, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Shipments/OpenShipment ");
                    }
                    
                }
            }
        }
        }
    }
