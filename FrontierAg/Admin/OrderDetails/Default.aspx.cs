using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Web.ModelBinding;
using System.Collections.Specialized;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Microsoft.AspNet.FriendlyUrls;



namespace FrontierAg.Admin.OrderDetails
{
    public partial class Default : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        //decimal ProcessingFee;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Solution 1, to force browser to reload when using back button inorder to display updated info on page
            if (!IsPostBack)
            {
                PFeeBox.Text = "5.00";
                Response.Buffer = true;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "no-cache");
                Response.Expires = -1441;
            }
            //ProcessingFee = Convert.ToDecimal(PFeeBox.Text.ToString());; 
        }

        //Solution2, to force browser to reload when using back button inorder to display updated info on page
        //public class ProductBrowser : Page
        //{
        //    protected override void OnInit(EventArgs e)
        //    {
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Cache.SetNoStore();
        //        Response.Cache.SetExpires(DateTime.MinValue);

        //        base.OnInit(e);
        //    }
        //}
                
        public IQueryable<Order> OpenOrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId)
        {
            if (OrderId != null)
            {
                ProductContext db = new ProductContext();
                return db.Orders.Include(en => en.OrderShippings.Select(m => m.Shipping)).Where(en => en.OrderId == OrderId);
            }
            else return null;
            
        }
        

        public void OpenOrders_UpdateItem(Order order)
        {
            if (order != null)
            {
                using (ProductContext db = new ProductContext())
                {
                    
                    //grab original order from DB
                    var originalOrder = db.Orders.Find(order.OrderId);
                    
                    originalOrder.ShipCharge = order.ShipCharge;
                    originalOrder.Comment = order.Comment;
                    originalOrder.Tracking = order.Tracking;
                    originalOrder.Status = order.Status;
                    
                    var AllOrderItems = db.OrderDetails.Where(en => en.OrderId == order.OrderId);
                    var isRemaining = 0;
                    foreach(var b in AllOrderItems)
                    {
                        if (b.QtyShipped + b.QtyCancelled != b.Quantity)
                        {
                            isRemaining = 1;
                        }
                    }

                    if (isRemaining == 0)///////////////////order.Status == Status.Shipped &&//When to updat the total? when no more QTYremaining ? or when we shipp an item?
                    {
                        //valuse of items
                        Decimal itemsValue = 0, itemCharges;                         
                        foreach(var a in AllOrderItems)
                        {
                            OrderActions actions = new OrderActions();
                            itemCharges = actions.GetChargeFromPackCharges(a.ProductId, a.QtyShipped);

                            itemsValue = itemsValue + (a.QtyShipped * a.UnitPrice) + itemCharges;
                        }
                        originalOrder.Total = itemsValue + order.ShipCharge;//+ originalOrder.OtherCharge - originalOrder.Discount + originalOrder.PFee               
                    }
                    db.SaveChanges();                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>


        public IQueryable<OrderDetail> OpenOrderList_GetData([FriendlyUrlSegmentsAttribute(0)] int? OrderId) 
        {
            if (OrderId != null)
            {
                OrderActions actions = new OrderActions();
                return actions.GetOrderItems(OrderId);
            }
            else return null;
        }

        protected void SvToShipment_Click(object sender, EventArgs e)//////////////1
        {                      
            Decimal PFee = Convert.ToDecimal(PFeeBox.Text.ToString());
            IList<string> segments = Request.GetFriendlyUrlSegments();  

            SaveUpdateOrderDetail(int.Parse(segments[0]), PFee);///////////////2     
        }

        public IQueryable<OrderDetail> SaveUpdateOrderDetail(int OrderId, Decimal PFee)/////////////////////3
        {
            //String cartId = usersShoppingCart.GetCartId();
            using (OrderActions MyOrderActions = new OrderActions())
            {
                OrderActions.OrederDetailUpdates[] ODUpdates = new OrderActions.OrederDetailUpdates[OrderDetailList.Rows.Count];

                for (int i = 0; i < OrderDetailList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(OrderDetailList.Rows[i]);
                    ODUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductId"]);

                    Label ProductNoLbl = new Label();
                    ProductNoLbl = (Label)OrderDetailList.Rows[i].FindControl("ProductNo");
                    ODUpdates[i].ProductNo = Convert.ToString(ProductNoLbl.Text.ToString());                    

                    Label ProductNameLbl = new Label();
                    ProductNameLbl = (Label)OrderDetailList.Rows[i].FindControl("ProductName");
                    ODUpdates[i].ProductName = Convert.ToString(ProductNameLbl.Text.ToString());                    

                    ODUpdates[i].Quantity = Convert.ToUInt16(rowValues["Quantity"]);
                    ODUpdates[i].UnitString = Convert.ToString(rowValues["Unit"]);
                    ODUpdates[i].QtyShipped = Convert.ToInt16(rowValues["QtyShipped"]);
                    ODUpdates[i].QtyCancelled = Convert.ToInt16(rowValues["QtyCancelled"]);
                    ODUpdates[i].Price = Convert.ToDecimal(rowValues["PriceOverride"]);
                    
                    TextBox QtyShippedTextBox = new TextBox();
                    QtyShippedTextBox = (TextBox)OrderDetailList.Rows[i].FindControl("QtyShippingBx");
                    ODUpdates[i].QtyShipping = Convert.ToInt16(QtyShippedTextBox.Text.ToString());

                    TextBox QtyCancelledTextBox = new TextBox();
                    QtyCancelledTextBox = (TextBox)OrderDetailList.Rows[i].FindControl("QtyCancellingBx");
                    ODUpdates[i].QtyCancelling = Convert.ToInt16(QtyCancelledTextBox.Text.ToString());

                    TextBox CommentBox = new TextBox();
                    CommentBox = (TextBox)OrderDetailList.Rows[i].FindControl("CommentBx");
                    ODUpdates[i].Comment = CommentBox.Text.ToString();

                }

                MyOrderActions.UpdateOrderDetailDatabase(OrderId, ODUpdates, PFee);//////////////////4
                OrderDetailList.DataBind();
                
                return MyOrderActions.GetOrderDetailsItems(OrderId);
            }
        }

        

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Orders/OpenOrder");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();

            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int myOrderId = Int32.Parse(yourValue);
            using (ProductContext db = new ProductContext())
            {
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.Shipping.SType == SType.Shipping).Select(en => en.ShippingId).FirstOrDefault();

                Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Default",0, myShippingId));
                
            }
        }

        public IQueryable<FrontierAg.Models.Shipping> ShippingsGrid_GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId)//[FriendlyUrlSegmentsAttribute(0)]int? ContactId, [FriendlyUrlSegmentsAttribute(1)]int? ShippingId)
        {
            //if (ContactId == 0 && ShippingId != null)
            //{
            //    return _db.Shippings.Where(n => n.ShippingId == ShippingId);//.Include(m => m.Contact);//////////
            //}

            if (OrderId != null)
            {
                var myShippingId3 = (from my in _db.OrderShippings
                                     where my.OrderId == OrderId && my.Shipping.SType == SType.Shipping
                                     select my.Shipping);

                return myShippingId3;// _db.OrderShippings.Include(m => m.Contact);
            }


            else return null;// _db.OrderShippings.Where(n => n.OrderId == OrderId && n.Shipping.isShipping == true).Select(en => en.Shipping);//.Include(m => m.Contact);//////////
        }
        public void ShippingsGrid_UpdateItem(int ShippingId)
        {
            FrontierAg.Models.Shipping item = null;
            item = _db.Shippings.Find(ShippingId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ShippingId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                _db.SaveChanges();
            }
        }


        protected void ShipmentsBtn_Click(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            int myOrderId = int.Parse(segments[0]);

            using (ProductContext db = new ProductContext())
            {
                //var myShipmentId = db.Shipments.Select(en => en.ShipmentId).FirstOrDefault();//Where(en => en.OrderId == myOrderId).Select(en => en.ShipmentId).FirstOrDefault();
                Response.Redirect(FriendlyUrl.Href("~/Admin/Shipments/Default", myOrderId));
            }
        }
               

    }
}