using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public System.DateTime OrderDate { get; set; }
                       
        public decimal Total { get; set; }
        
        public int ContactId { get; set; }
                
        public string TransactionId { get; set; }

        public System.DateTime TransactionDate { get; set; }
                
        public bool HasBeenShipped { get; set; }

        public virtual Contact Contact { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}