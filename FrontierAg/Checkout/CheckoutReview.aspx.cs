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
        decimal orderTotal = 0;
        //int myOrderId2;

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                orderTotal = usersShoppingCart.GetTotal();
                lblTotal.Text = String.Format("{0:c}", orderTotal);
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

        public FrontierAg.Models.Shipping GetItem1([FriendlyUrlSegmentsAttribute(1)]int ShippingId)
        {
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                return _db.Shippings.Where(m => m.ShippingId == ShippingId).FirstOrDefault();
            }
        }

        public FrontierAg.Models.Shipping GetItem2([FriendlyUrlSegmentsAttribute(2)]int ShippingId)
        {
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                return _db.Shippings.Where(m => m.ShippingId == ShippingId).FirstOrDefault();
            }
        }

        public FrontierAg.Models.Shipping GetItem3([FriendlyUrlSegmentsAttribute(3)]int ShippingId)
        {
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                return _db.Shippings.Where(m => m.ShippingId == ShippingId).FirstOrDefault();
            }
        }
        


        protected void RecurringButton_Click(object sender, EventArgs e)
        {
            DateTime StartDate = Convert.ToDateTime(StartTxb.Text);
            DateTime EndDate = Convert.ToDateTime(EndTxb.Text);
            string Frequent = RepeatDdl.SelectedItem.ToString().Trim();      

            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();
                List<CartItem> MyCart = usersShoppingCart.GetCartItems();

                if (Frequent.Equals("Daily"))
                {
                    for (DateTime i = StartDate; i < EndDate; i = i.AddDays(1))
                    {
                        if (i.DayOfWeek != DayOfWeek.Saturday || i.DayOfWeek != DayOfWeek.Sunday)
                        {
                            //Place an order
                            AddOrder(PaymentBox.Text, CommentBox.Text, MyCart, i);   //PaymentDateBox.Text,                         
                        }                        
                    }
                }
                else if (Frequent.Equals("Weekly"))
                {
                    for (DateTime i = StartDate; i < EndDate; i = i.AddDays(7))
                    {
                        //Place an order
                        AddOrder(PaymentBox.Text, CommentBox.Text, MyCart, i);                         
                    }
                }
                else if (Frequent.Equals("BiWeekly"))
                {
                    for (DateTime i = StartDate; i < EndDate; i = i.AddDays(14))
                    {
                        //Place an order
                        AddOrder(PaymentBox.Text, CommentBox.Text, MyCart, i);                        
                    }
                }

                else
                {
                    for (DateTime i = StartDate; i < EndDate; i = i.AddDays(30))
                    {
                        //Place an order
                        AddOrder(PaymentBox.Text, CommentBox.Text, MyCart, i);                         
                    }
                } 
            }
            Session["isStandOrder"] = "true";

            //To get company name and store it in session
            IList<string> segments = Request.GetFriendlyUrlSegments();
            using (ProductContext _db = new ProductContext())
            {
            int x = int.Parse(segments[0]);
            var myContact = _db.Contacts.Where(en => en.ContactId == x).SingleOrDefault();
            Session["OrderedBy"] = myContact.Company;
            }

            RemoveCartItems();
            Response.Redirect("~/Checkout/CheckoutComplete");//To send emails   
            
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout/CheckoutCancel");
        }


        protected void PlaceOrderBtn_Click(object sender, EventArgs e)//1
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();

                List<CartItem> MyCart = usersShoppingCart.GetCartItems();

                //Place an order
                AddOrder(PaymentBox.Text, CommentBox.Text, MyCart, System.DateTime.Now);//PaymentDateBox.Text,
                RemoveCartItems();
            }
            Response.Redirect("~/Checkout/CheckoutComplete");//To send emails
            
        }

        public bool AddOrder(string Payment, string CommentBox, List<CartItem> MyCart, DateTime myDate)//string PaymentDate,
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();

            using (ProductContext _db = new ProductContext())
            {
                //create new customer
                int x = int.Parse(segments[0]);
                var myContact = _db.Contacts.Where(e => e.ContactId == x).SingleOrDefault();
                var myCustomer = new Customer();
                myCustomer.Company = myContact.Company;
                //myCustomer.LName = myContact.LName;
                //myCustomer.FName = myContact.FName;
                myCustomer.Address1 = myContact.Address1;
                myCustomer.Address2 = myContact.Address2;
                myCustomer.City = myContact.City;
                myCustomer.State = myContact.State;
                myCustomer.PostalCode = myContact.PostalCode;
                myCustomer.Country = myContact.Country;
                myCustomer.PPhone = myContact.PPhone;
                myCustomer.SPhone = myContact.SPhone;
                myCustomer.WebSite = myContact.WebSite;
                myCustomer.EMail = myContact.EMail;
                myCustomer.DateCreated = myDate; // System.DateTime.Now;
                myCustomer.Fax = myContact.Fax;
                myCustomer.Comment = myContact.Comment;

                _db.Customers.Add(myCustomer);

                //Create new order
                var myOrder = new Order();
                myOrder.OrderDate = myDate;
                myOrder.CreatedBy = HttpContext.Current.User.Identity.Name;
                myOrder.CustomerId = myCustomer.CustomerId;
                myOrder.Total = orderTotal;
                myOrder.Status = Status.New;
                if (Payment == "")
                {
                    myOrder.Payment = "";
                }
                else
                {
                    myOrder.Payment = Payment;
                }
                //if (PaymentDate == "")
                //{
                //    myOrder.PaymentDate = null;
                //}
                //else
                //{
                //    myOrder.PaymentDate = Convert.ToDateTime(PaymentDate);
                //}
                myOrder.ContactId = int.Parse(segments[0]);
                myOrder.Comment = CommentBox;
                //myOrder.PFee = ProcessingFee;
                _db.Orders.Add(myOrder);

                //Create new OrderingPerson to Link to myOrder
                var myOrderingPerson = new Shipping();
                var myExistingOrdering = _db.Shippings.Find(int.Parse(segments[1]));
                myOrderingPerson.Company = myExistingOrdering.Company;
                myOrderingPerson.LName = myExistingOrdering.LName;
                myOrderingPerson.FName = myExistingOrdering.FName;
                myOrderingPerson.Other1 = myExistingOrdering.Other1;
                myOrderingPerson.Other2 = myExistingOrdering.Other2;
                myOrderingPerson.Address1 = myExistingOrdering.Address1;
                myOrderingPerson.Address2 = myExistingOrdering.Address2;
                myOrderingPerson.City = myExistingOrdering.City;
                myOrderingPerson.State = myExistingOrdering.State;
                myOrderingPerson.PostalCode = myExistingOrdering.PostalCode;
                myOrderingPerson.Country = myExistingOrdering.Country;
                myOrderingPerson.ContactId = myExistingOrdering.ContactId;
                myOrderingPerson.PPhone = myExistingOrdering.PPhone;
                myOrderingPerson.EMail = myExistingOrdering.EMail;
                myOrderingPerson.isHistory = true;
                //myOrderingPerson.SType = SType.Ordering;
                myOrderingPerson.DateCreated = myDate; // System.DateTime.Now;
                _db.Shippings.Add(myOrderingPerson);

                //create OrderShipping for OrderingPerson
                var myOrderShipping0 = new OrderShipping();
                myOrderShipping0.ShippingId = myOrderingPerson.ShippingId;
                myOrderShipping0.OrderId = myOrder.OrderId;
                myOrderShipping0.SType = SType.Ordering;
                _db.OrderShippings.Add(myOrderShipping0);

                _db.SaveChanges();

                //Create new Shipping Address to Link to myOrder
                var myShipping = new Shipping();
                var myExistingShipping = _db.Shippings.Find(int.Parse(segments[2]));
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
                myShipping.EMail = myExistingShipping.EMail;
                myShipping.isHistory = true;
                //myShipping.SType = SType.Shipping;
                myShipping.DateCreated = myDate; // System.DateTime.Now;
                _db.Shippings.Add(myShipping);

                //create OrderShipping for shipping
                var myOrderShipping1 = new OrderShipping();
                myOrderShipping1.ShippingId = myShipping.ShippingId;
                myOrderShipping1.OrderId = myOrder.OrderId;
                myOrderShipping1.SType = SType.Shipping;
                _db.OrderShippings.Add(myOrderShipping1);

                _db.SaveChanges();

                //Create new Billing Address to Link to myOrder
                var myBilling = new Shipping();
                var myExistingBilling = _db.Shippings.Find(int.Parse(segments[3]));
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
                myBilling.EMail = myExistingBilling.EMail;
                myBilling.isHistory = true;
                //myBilling.SType = SType.Billing;
                myBilling.DateCreated = myDate; // System.DateTime.Now;
                _db.Shippings.Add(myBilling);

                //create OrderShipping for billing
                var myOrderShipping2 = new OrderShipping();
                myOrderShipping2.ShippingId = myBilling.ShippingId;
                myOrderShipping2.OrderId = myOrder.OrderId;
                myOrderShipping2.SType = SType.Billing;
                _db.OrderShippings.Add(myOrderShipping2);

                //Add OrderDetail
                foreach (var cartItem in MyCart)
                {
                    var myOrderDetail = new OrderDetail();
                    myOrderDetail.OrderId = myOrder.OrderId;
                    myOrderDetail.ProductId = cartItem.ProductId;
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
                Session["OrderId"] = myOrder.OrderId;
                Session["OrderedBy"] = myOrder.Contact.Company;
            }
            // Success.
            return true;
        }
                

    }
}