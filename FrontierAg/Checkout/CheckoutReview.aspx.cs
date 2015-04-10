using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        decimal cartTotal = 0;

        static int myContactId;

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
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

        public List<CartItem> UpdateCartItems2()
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
                    //cbRemove = (CheckBox)CheckoutReviewList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = true;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CheckoutReviewList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = 0;//Convert.ToInt16(quantityTextBox.Text.ToString());
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


        public FrontierAg.Models.Contact GetItem([FriendlyUrlSegmentsAttribute(0)]int? ContactIdRaw)
        {
            int? ContactId = ContactIdRaw / 10;

            

            if (ContactId == null)
            {
                return null;
            }
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {

                myContactId = (int)ContactId;
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

        //protected FrontierAg.Models.ProductContext _db2 = new FrontierAg.Models.ProductContext();

        public FrontierAg.Models.Shipping GetItem2([FriendlyUrlSegmentsAttribute(0)]int? ShippingIdRaw)
        {
            int? ShippingId = ShippingIdRaw % 10;

            if (ShippingId == null)
            {
                return null;
            }

            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                return _db.Shippings.Where(m => m.ShippingId == ShippingId).FirstOrDefault();
            }
        }


        protected void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();/////////////////////
                AddOrder(TransactionIdBox.Text, TransactionIdDateBox.Text);
                UpdateCartItems2();
                //AddOrderDetail(TransactionIdBox.Text, TransactionIdDateBox.Text);
            }
            Response.Redirect("~/Checkout/CheckoutComplete.aspx");
        }


        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Checkout/CheckoutCancel");
        }


        public bool AddOrder(string TransactionId, string TransactionIdDate)
        {
            var myOrder = new Order();
            myOrder.OrderDate = System.DateTime.Now;
            myOrder.Total = cartTotal;
            myOrder.HasBeenShipped = false;
            myOrder.ContactId = myContactId;
            if (TransactionId == "")
            {
                myOrder.TransactionId = "0";
            }
            else
            {
                myOrder.TransactionId =  TransactionId;
            }
            if (TransactionIdDate == "")
            {
                myOrder.TransactionDate = Convert.ToDateTime("01/01/1900");
            }
            else
            {
                myOrder.TransactionDate = Convert.ToDateTime(TransactionIdDate);
            }
            

            using (ProductContext _db = new ProductContext())
            {
                // Add product to DB.
                _db.Orders.Add(myOrder);

                _db.SaveChanges();
            }
            // Success.
            return true;
        }

        //public bool AddOrderDetail(string TransactionId, string TransactionIdDate)
        //{
        //    var myOrderDetail = new OrderDetail();

        //    using (ProductContext _db = new ProductContext())
        //    {
        //        myOrderDetail.OrderId = _db.Orders.Last().OrderId;
        //    }
           
        //    myOrderDetail.Total = cartTotal;
        //    myOrderDetail.HasBeenShipped = false;
        //    myOrderDetail.ContactId = myContactId;
        //    myOrderDetail.TransactionId = TransactionId;
        //    myOrderDetail.TransactionDate = Convert.ToDateTime(TransactionIdDate);

        //    using (ProductContext _db = new ProductContext())
        //    {
        //        // Add product to DB.
        //        _db.Orders.Add(myOrderDetail);
        //        _db.SaveChanges();
        //    }
        //    // Success.
        //    return true;
        //}


        
    }
}