using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class ProductContext : ApplicationDbContext
    {
        public ProductContext() : base("FrontierAg")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }        
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<PackCharge> PackCharges { get; set; }
        public DbSet<OrderShipping> OrderShippings { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; } 
    }
}