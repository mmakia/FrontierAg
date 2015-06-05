using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls; 

namespace FrontierAg.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        decimal cartTotal = 0;
        decimal orderTotal = 0;
        decimal ProcessingFee;          

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                if (!IsPostBack)
                {
                    //PFeeBox.Text = "5.00";
                }
                //ProcessingFee = Convert.ToDecimal(PFeeBox.Text.ToString());  
                cartTotal = usersShoppingCart.GetTotal();
                orderTotal = cartTotal;// +ProcessingFee;
                if (cartTotal > 0)
                {                    
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);                    
                    //GTotalValueLbl.Text = String.Format("{0:c}", orderTotal);                    
                }
                else
                {
                    //LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    CheckoutReviewTitle.InnerText = "Shopping Cart is Empty";
                    PlaceOrderBtn.Visible = false;
                }
            }
           
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }

        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CheckoutReviewList.Rows.Count];
                for (int i = 0; i < CheckoutReviewList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CheckoutReviewList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CheckoutReviewList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CheckoutReviewList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CheckoutReviewList.DataBind();

                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal()); 
                return usersShoppingCart.GetCartItems();
            }
        }

        public List<CartItem> RemoveCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CheckoutReviewList.Rows.Count];
                for (int i = 0; i < CheckoutReviewList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CheckoutReviewList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cartUpdates[i].RemoveItem = true;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CheckoutReviewList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = 0;
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CheckoutReviewList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
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


        public FrontierAg.Models.Contact GetItem([FriendlyUrlSegmentsAttribute(0)]int ContactId)
        {            
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {               
                return _db.Contacts.Where(m => m.ContactId == ContactId).FirstOrDefault();
            }
        }


        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }

        public FrontierAg.Models.Shipping GetItem2([FriendlyUrlSegmentsAttribute(1)]int ShippingId)
        {
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                return _db.Shippings.Where(m => m.ShippingId == ShippingId).FirstOrDefault();
            }
        }

        public FrontierAg.Models.Shipping GetItem3([FriendlyUrlSegmentsAttribute(2)]int ShippingId)
        {
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                return _db.Shippings.Where(m => m.ShippingId == ShippingId).FirstOrDefault();
            }
        }


        protected void PlaceOrderBtn_Click(object sender, EventArgs e)
        {                         
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();
                
                List<CartItem> MyCart = usersShoppingCart.GetCartItems();
                
                //Place an order
                AddOrder(PaymentBox.Text, PaymentDateBox.Text, CommentBox.Text, MyCart);
                RemoveCartItems();                
            }
            //new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            //new Emailer().SendEmail("snacko@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            //new Emailer().SendEmail("ugatti@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            //new Emailer().SendEmail("rwright@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            //new Emailer().SendEmail("ddavis@fsiag.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            //new Emailer().SendEmail("mvella@fsiag.com ", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            //new Emailer().SendEmail("mwoolman@frontierssi.com ", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            Response.Redirect("~/Checkout/CheckoutComplete.aspx");               
        }
        
        protected void CancelBtn_Click(object sender, EventArgs e)
        {            
            Response.Redirect("~/Checkout/CheckoutCancel");
        }

        public bool AddOrder(string Payment, string PaymentDate, string CommentBox, List<CartItem> MyCart)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();

            using (ProductContext _db = new ProductContext())
            {                
                //Create new order
                var myOrder = new Order();
                myOrder.OrderDate = System.DateTime.Now;
                myOrder.Total = orderTotal;
                myOrder.Status = Status.New;                                                                        
                if (Payment == "")
                {
                    myOrder.Payment = "";
                }
                else
                {
                    myOrder.Payment =  Payment;
                }
                if (PaymentDate == "")
                {
                    myOrder.PaymentDate = null;
                }
                else
                {
                    myOrder.PaymentDate = Convert.ToDateTime(PaymentDate);
                }
                myOrder.ContactId = int.Parse(segments[0]);
                myOrder.Comment = CommentBox;
                //myOrder.PFee = ProcessingFee;
                _db.Orders.Add(myOrder);          

                //Create new Shipping Address to Link to myOrder
                var myShipping = new Shipping();
                var myExistingShipping = _db.Shippings.Find(int.Parse(segments[1]));
                myShipping.Company = myExistingShipping.Company;
                myShipping.LName = myExistingShipping.LName;
                myShipping.FName = myExistingShipping.FName;
                myShipping.Other1 = myExistingShipping.Other1;
                myShipping.Other2 = myExistingShipping.Other2;
                myShipping.Address1 = myExistingShipping.Address1;
                myShipping.Address2 = myExistingShipping.Address2;
                myShipping.City = myExistingShipping.City;
                myShipping.State = myExistingShipping.State;
                myShipping.PostalCode = myExistingShipping.PostalCode;
                myShipping.Country = myExistingShipping.Country;
                myShipping.ContactId = myExistingShipping.ContactId;
                myShipping.PPhone = myExistingShipping.PPhone;
                myShipping.isHistory = true;
                myShipping.SType = SType.Shipping;
                myShipping.DateCreated = System.DateTime.Now;
                _db.Shippings.Add(myShipping);

                //create OrderShipping for shipping
                var myOrderShipping1 = new OrderShipping();
                myOrderShipping1.ShippingId = myShipping.ShippingId;
                myOrderShipping1.OrderId = myOrder.OrderId;
                _db.OrderShippings.Add(myOrderShipping1);

                _db.SaveChanges();

                //Create new Billing Address to Link to myOrder
                var myBilling = new Shipping();
                var myExistingBilling = _db.Shippings.Find(int.Parse(segments[2]));
                myBilling.Company = myExistingBilling.Company;
                myBilling.LName = myExistingBilling.LName;
                myBilling.FName = myExistingBilling.FName;
                myBilling.Other1 = myExistingBilling.Other1;
                myBilling.Other2 = myExistingBilling.Other2;
                myBilling.Address1 = myExistingBilling.Address1;
                myBilling.Address2 = myExistingBilling.Address2;
                myBilling.City = myExistingBilling.City;
                myBilling.State = myExistingBilling.State;
                myBilling.PostalCode = myExistingBilling.PostalCode;
                myBilling.Country = myExistingBilling.Country;
                myBilling.ContactId = myExistingBilling.ContactId;
                myBilling.PPhone = myExistingBilling.PPhone;
                myBilling.isHistory = true;
                myBilling.SType = SType.Billing;
                myBilling.DateCreated = System.DateTime.Now;
                _db.Shippings.Add(myBilling);

                //create OrderShipping for billing
                var myOrderShipping2 = new OrderShipping();
                myOrderShipping2.ShippingId = myBilling.ShippingId;
                myOrderShipping2.OrderId = myOrder.OrderId;
                _db.OrderShippings.Add(myOrderShipping2);

                //Add OrderDetail
                foreach (var cartItem in MyCart)
                {
                    var myOrderDetail = new OrderDetail();
                    myOrderDetail.OrderId = myOrder.OrderId;
                    myOrderDetail.ProductId = cartItem.ProductId;//do we need it, should we copy it?
                    myOrderDetail.Quantity = cartItem.Quantity;
                    myOrderDetail.Unit = cartItem.Unit;
                    myOrderDetail.QtyShipped = 0;
                    //myOrderDetail.QtyShipping = 0;
                    myOrderDetail.QtyCancelled = 0;
                    myOrderDetail.DateCreated = myOrder.OrderDate;
                    myOrderDetail.UnitPrice = cartItem.OriginalPrice;
                    myOrderDetail.PriceOverride = cartItem.ItemPrice;

                    // Add product to DB.
                    _db.OrderDetails.Add(myOrderDetail);
                
                    //Save Changes
                    _db.SaveChanges();
                }
            }
            // Success.
            return true;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.Contact> CustomerGrid_GetData()
        {
            return null;
        }               
               
    }
}