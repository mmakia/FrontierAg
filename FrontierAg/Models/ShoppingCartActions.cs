using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private ProductContext _db = new ProductContext();

        public const string CartSessionKey = "CartId";

        public int CartSessionFlag = 0;


        public void AddToCart(int id)//done----------------------------------( 1 )
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);                

                if (cartItem == null)
                {
                    // Create a new cart item if no cart item exists.                 
                    cartItem = new CartItem
                    {
                        ItemId = Guid.NewGuid().ToString(),
                        ProductId = id,
                        CartId = ShoppingCartId,
                        Quantity = GetMinQty(id),
                        ItemPrice = GetPriceforMinQty(id),                        
                        Product = _db.Products.SingleOrDefault(p => p.ProductId == id),
                        DateCreated = DateTime.Now
                    };

                    _db.ShoppingCartItems.Add(cartItem);
                }
                else
                {                                    
                    cartItem.Quantity++;                    
                    cartItem.ItemPrice = GetPriceFromPrices(cartItem.ProductId, cartItem.Quantity);
                }
                _db.SaveChanges();            
        }

        protected Decimal GetPriceFromPrices(int productId, int qty)//done------ ( 2 )
        {
             
            var myItem = _db.Prices.Where(en => en.ProductId == productId && en.From <= qty && en.To >= qty).FirstOrDefault();

            if (myItem != null)
            {
                return myItem.PriceNumber;
            }

            return 0;
        }        

        protected int GetMinQty(int id)//done------- ( 3 )
        {
            if (_db.Prices.Any(m => m.ProductId == id))
            {
                return _db.Prices.Where(m => m.ProductId == id).Min(n => n.From);
            }

            return 0;
        }

        protected Decimal GetPriceforMinQty(int id)//done--------------( 4 )
        {
            int myInt = GetMinQty(id);

            if (_db.Prices.Any(m => m.ProductId == id))
            {
                return _db.Prices.Where(m => m.ProductId == id && m.From == myInt).Select(n => n.PriceNumber).SingleOrDefault();
            }

            return 0;            
        }
        

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()//done ------- default
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()//done ------ default
        {
            ShoppingCartId = GetCartId();

            return _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }

        

        public ShoppingCartActions GetCart(HttpContext context)//done ---------- default
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)//, string ProductIdBox, string PriceBox)
        {                            
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartItem> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Product.ProductId == CartItemUpdates[i].ProductId) 
                            {
                                if (CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProductId);                                    
                                }
                                else
                                {                                    
                                        UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity, CartItemUpdates[i].PriceBx);                                                                          
                                }
                            }                            
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);  ///error input string was not in correct format                  
                }
                
           
            
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new FrontierAg.Models.ProductContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartItems where c.CartId == removeCartID && c.Product.ProductId == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.ShoppingCartItems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();            
            decimal? total = decimal.Zero;            
                
                total = (decimal?)(from cartItems in _db.ShoppingCartItems
                                   where cartItems.CartId == ShoppingCartId
                                   select (int?)cartItems.Quantity * cartItems.ItemPrice).Sum();
                
                return total ?? decimal.Zero;      
            
        }

        
        public void UpdateItem(string updateCartID, int updateProductID, int quantity, Decimal Price)// execute when changing price box 
        {
            using (var _db = new FrontierAg.Models.ProductContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartItems where c.CartId == updateCartID && c.Product.ProductId == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {           

                        if (myItem != null)
                        {
                            if(myItem.Quantity != quantity)
                            {
                                myItem.ItemPrice = GetPriceFromPrices(updateProductID, quantity);
                            }
                            else
                            {
                                myItem.ItemPrice = Price;
                            }
                            CartSessionFlag = 0;                            
                            myItem.Quantity = quantity;
                            _db.SaveChanges();                            
                        }
                        else
                        {
                            CartSessionFlag = updateProductID;
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }   

        

        //public void UpdateItem(string updateCartID, int updateProductID, int quantity)//execute when changing Qty box
        //{              
        //    using (var _db = new FrontierAg.Models.ProductContext())
        //    {
        //        try
        //        {
        //            var myItem = (from c in _db.ShoppingCartItems where c.CartId == updateCartID && c.Product.ProductId == updateProductID select c).FirstOrDefault();
        //            if (myItem != null)
        //            {
        //                if (myItem != null)
        //                {
        //                    CartSessionFlag = 0;
        //                    if (myItem.Quantity != quantity)
        //                    {
        //                        myItem.ItemPrice = GetPriceFromPrices(updateProductID, quantity);
        //                    }                            
        //                    myItem.Quantity = quantity;
        //                    _db.SaveChanges();
        //                }
        //                else
        //                {
        //                    CartSessionFlag = updateProductID;
        //                }                                                  
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
        //        }
        //    }
        //}

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.ShoppingCartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public Decimal PriceBx;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateCart(string cartId, string userName)
        {
            var shoppingCart = _db.ShoppingCartItems.Where(c => c.CartId == cartId);
            foreach (CartItem item in shoppingCart)
            {
                item.CartId = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            _db.SaveChanges();
        }

    }
}