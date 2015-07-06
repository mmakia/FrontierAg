using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } 

        public int OrderId { get; set; }        

        public int ProductId { get; set; }

        public string ProductNo { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }        

        public int QtyShipped { get; set; }        

        public int QtyCancelled { get; set; }

        //[Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }//decimal

        //[Column(TypeName = "money")]
        public decimal PriceOverride { get; set; }//decimal

        public Unit Unit { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public string Comment { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        //public virtual ICollection<Shipment> Shipments { get; set; }

    }
}