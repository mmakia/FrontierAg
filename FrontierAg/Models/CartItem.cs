using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        //[Column(TypeName = "money")]
        public decimal ItemPrice { get; set; }//decimal

        //[Column(TypeName = "money")]
        public decimal OriginalPrice { get; set; }//decimal

        public int Quantity { get; set; }        

        public Unit Unit { get; set; }

        public System.DateTime DateCreated { get; set; }
        
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
                
    }
}