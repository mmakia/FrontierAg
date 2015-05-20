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

        //Decimal TotalWOShipping;       
        Decimal newTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// //////////////////
        /// </summary>
        /// <returns></returns>
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

                    if (order.Status == Status.Shipped && isRemaining == 0)///////////////////
                    {
                        //valuse of cancelled items
                        Decimal itemsValue = 0;                         
                        foreach(var a in AllOrderItems)
                        {
                            itemsValue = itemsValue + (a.QtyShipped * a.UnitPrice);
                        }
                        originalOrder.Total = itemsValue + originalOrder.OtherCharge - originalOrder.Discount + 5 + order.ShipCharge;                        
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

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            //string rawId = Request.QueryString["OrderId"];

            IList<string> segments = Request.GetFriendlyUrlSegments();
            //x = int.Parse(segments[0]);


            UpdateOrderDetail(int.Parse(segments[0]));            
        }

        public IQueryable<OrderDetail> UpdateOrderDetail(int OrderId)
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

                    TextBox QtyShippedTextBox = new TextBox();
                    QtyShippedTextBox = (TextBox)OrderDetailList.Rows[i].FindControl("QtyShippedBx");
                    ODUpdates[i].QtyShipped = Convert.ToInt16(QtyShippedTextBox.Text.ToString());

                    TextBox QtyCancelledTextBox = new TextBox();
                    QtyCancelledTextBox = (TextBox)OrderDetailList.Rows[i].FindControl("QtyCancelledBx");
                    ODUpdates[i].QtyCancelled = Convert.ToInt16(QtyCancelledTextBox.Text.ToString());

                    TextBox CommentBox = new TextBox();
                    CommentBox = (TextBox)OrderDetailList.Rows[i].FindControl("CommentBx");
                    ODUpdates[i].Comment = CommentBox.Text.ToString();

                }

                MyOrderActions.UpdateOrderDetailDatabase(OrderId, ODUpdates);
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
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.Shipping.isShipping == true).Select(en => en.ShippingId).FirstOrDefault();

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
                                     where my.OrderId == OrderId && my.Shipping.isShipping == true
                                     select my.Shipping);

                return myShippingId3;// _db.OrderShippings.Include(m => m.Contact);
            }


            else return null;// _db.OrderShippings.Where(n => n.OrderId == OrderId && n.Shipping.isShipping == true).Select(en => en.Shipping);//.Include(m => m.Contact);//////////
        }

               

    }
}