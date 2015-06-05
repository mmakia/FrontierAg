using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public Decimal ItemPrice { get; set; }

        public Decimal OriginalPrice { get; set; }

        public int Quantity { get; set; }        

        public Unit Unit { get; set; }

        public System.DateTime DateCreated { get; set; }
        
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
                
    }
}