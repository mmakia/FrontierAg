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
                        OriginalPrice = GetPriceforMinQty(id),
                        ItemPrice = GetPriceforMinQty(id),
                        //Charge = GetChargeFromMinQty(id),
                        Product = _db.Products.SingleOrDefault(p => p.ProductId == id),
                        Unit = GetUnit(id,GetMinQty(id)),
                        DateCreated = DateTime.Now
                    };

                    _db.ShoppingCartItems.Add(cartItem);
                }
                else
                {                                    
                    cartItem.Quantity++;                    
                    cartItem.ItemPrice = GetPriceFromPrices(cartItem.ProductId, cartItem.Quantity);
                    cartItem.Unit = GetUnit(cartItem.ProductId, cartItem.Quantity); //_db.Prices.Where(p => p.From >= GetPriceFromPrices(cartItem.ProductId, cartItem.Quantity) && p.To >= GetPriceFromPrices(cartItem.ProductId, cartItem.Quantity)).Select(en => en.Unit).SingleOrDefault();
                    //cartItem.Charge = GetChargeFromPackCharges(cartItem.ProductId, cartItem.Quantity);
                }
                _db.SaveChanges();            
        }

        private Unit GetUnit(int ProductId, int qty)
        {            
                try
                {
                    var myItem = _db.Prices.Where(en => en.ProductId == ProductId && en.From <= qty && en.To >= qty).FirstOrDefault();

                    if (myItem != null)
                    {
                        return myItem.Unit;
                    }
                    return Unit.Jug;
                }
                    catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to get Unit - " + exp.Message.ToString(), exp);
                }
        }

        //private decimal GetChargeFromPackCharges(int productId, int qty)//done------ ( 2 )
        //{
        //    var x = _db.PackCharges.Where(en => en.ProductId == productId).FirstOrDefault();
        //    if ( x == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        var myItem = _db.PackCharges.Where(en => en.ProductId == productId && en.From <= qty && en.To >= qty).FirstOrDefault();

        //        //found the value
        //        if (myItem != null)
        //        {
        //            return myItem.PackChargeAmt;
        //        }

        //        //value not found, will pack QTY in multipule boxes
        //        Decimal totalCharge = 0;



        //        //max qty fit in a box 
        //        var maxTo = _db.PackCharges.Where(en => en.ProductId == productId).Max(m => m.To);

        //        //the charge for max qty
        //        var maxToItem = _db.PackCharges.Where(en => en.ProductId == productId && en.To == maxTo).FirstOrDefault();

        //        //counting how many boxes needed
        //        while (qty > maxTo)
        //        {
        //            totalCharge = totalCharge + maxToItem.PackChargeAmt;
        //            qty = qty - maxTo;
        //        }
        //        //getting the charge for the box thats gonna fit the remaining
        //        var myItem2 = _db.PackCharges.Where(en => en.ProductId == productId && en.From <= qty && en.To >= qty).FirstOrDefault();

        //        //calculating total charge
        //        return totalCharge + myItem2.PackChargeAmt;
        //    }
        //}

        private decimal GetChargeFromMinQty(int id)
        {
            int myInt = GetMinQtyForCharge(id);

            if (_db.PackCharges.Any(m => m.ProductId == id))
            {
                return _db.PackCharges.Where(m => m.ProductId == id && m.From == myInt).Select(n => n.PackChargeAmt).SingleOrDefault();
            }

            return 0;  
        }

        private int GetMinQtyForCharge(int id)
        {
            if (_db.PackCharges.Any(m => m.ProductId == id))
            {
                return _db.PackCharges.Where(m => m.ProductId == id).Min(n => n.From);
            }

            return 0;
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

        public List<CartItem> GetCartItems()//done ------ default/////////++++++++++++++++++++
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

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {                            
                //try
                //{
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
                //}
                //catch (Exception exp)
                //{
                //    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);  ///error input string was not in correct format                  
                //}      ////////////
           
            
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
                                   select (int?)cartItems.Quantity * cartItems.ItemPrice).Sum();//+ cartItems.Charge
                
                return total ?? decimal.Zero;      
            
        }

        public decimal GetTotalQty()
        {
            ShoppingCartId = GetCartId();
            decimal? totalQty = decimal.Zero;

            totalQty = (decimal?)(from cartItems in _db.ShoppingCartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity).Sum();

            return totalQty ?? decimal.Zero;

        }
        
        public void UpdateItem(string updateCartID, int updateProductID, int quantity,  Decimal PriceOverride)// execute when changing price box or qty 
        {
            using (var _db = new FrontierAg.Models.ProductContext())
            {
                //try
                //{
                    //get item from CartItem Table in DB
                    var myItem = (from c in _db.ShoppingCartItems where c.CartId == updateCartID && c.Product.ProductId == updateProductID select c).FirstOrDefault();
                              
                 
                         if (myItem != null)
                        {
                            //if QTY changed, get price from table
                            if (myItem.Quantity != quantity)
                            {
                                myItem.Quantity = quantity;
                                myItem.ItemPrice = GetPriceFromPrices(updateProductID, quantity);
                                //myItem.Charge = GetChargeFromPackCharges(updateProductID, quantity);
                                myItem.OriginalPrice = myItem.ItemPrice;
                            }                                
                            else
                            {
                                //if Price changed, then use new price
                                myItem.ItemPrice = PriceOverride;
                            }
                                                       
                            CartSessionFlag = 0;                   
                            _db.SaveChanges();                            
                        }
                        else
                        {
                            CartSessionFlag = updateProductID;
                        }
                    
                //}
                //catch (Exception exp)
                //{
                //    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                //}
            }
        }   

        

        

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