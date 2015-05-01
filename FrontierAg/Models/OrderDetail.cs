using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } 

        public int OrderId { get; set; }        

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int QtyShipped { get; set; }

        public int QtyCancelled { get; set; }

        public Decimal UnitPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public string Comment { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

    }
}