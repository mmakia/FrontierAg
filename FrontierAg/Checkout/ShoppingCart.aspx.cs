﻿using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.ModelBinding;

namespace FrontierAg 
{
    public partial class ShoppingCart : System.Web.UI.Page
    {          

        protected void Page_Load(object sender, EventArgs e)
        {
             

            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {

                decimal cartTotal, cartTotalQty = 0;

                cartTotal = usersShoppingCart.GetTotal();
                cartTotalQty = usersShoppingCart.GetTotalQty();

                if (cartTotalQty > 0 || cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);                    
                    CheckoutBtn.Visible = true;
                    UpdateBtn.Visible = true;
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";                    
                    CheckoutBtn.Visible = false;
                    UpdateBtn.Visible = false;
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

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox priceTextBox = new TextBox();
                    priceTextBox = (TextBox)CartList.Rows[i].FindControl("PriceBx");
                    cartUpdates[i].PriceBx = Convert.ToDecimal(priceTextBox.Text.ToString());

                    //cartUpdates[i].ItemPrice = Convert.ToInt32(rowValues["OriginalPrice"]);

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                    
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);                
                CartList.DataBind();
                //GetTotal() suppose to execute after UpdateShoppingCartDatabase                
                string x = String.Format("{0:c}", usersShoppingCart.GetTotal());
                if (x != "$0.00")
                    lblTotal.Text = x;
                else
                    lblTotal.Text = "";
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

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();                     
        }

                
        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();
            }
            Response.Redirect("~/Checkout/CheckoutStart.aspx");
        }           
        
               
    }
} 