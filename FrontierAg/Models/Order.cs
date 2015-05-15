using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum Status
    {
        Cancelled, Processing, PartialShipment, Shipped, Other, Closed
    }

    public class Order
    {
        [Display(Name = "ID")]
        public int OrderId { get; set; }

        public System.DateTime OrderDate { get; set; }
                       
        public decimal Total { get; set; }        

        public int? ShippingId { get; set; }

        //public int ContactId { get; set; }
                
        public string Payment { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? PaymentDate { get; set; }
        
        public string Comment { get; set; }

        public Status Status { get; set; }

        public Decimal ShipCharge { get; set; }

        public Decimal OtherCharge { get; set; }

        public Decimal Discount { get; set; }

        public String Tracking { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        //public virtual Contact Contact { get; set; }

        public virtual Shipping Shipping { get; set; }
    }
}