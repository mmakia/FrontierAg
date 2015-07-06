using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum Status
    {
        Cancelled, New, InProcess, PartialShipment, Shipped, Closed
    }

    //public enum Action
    //{
    //    Hold, CancelOrder
    //}

    public class Order
    {
        [Display(Name = "ID")]
        public int OrderId { get; set; }

        public System.DateTime OrderDate { get; set; }

        //[Column(TypeName = "money")]
        public decimal Total { get; set; }//decimal

        public int? ContactId { get; set; }
                
        public string Payment { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? PaymentDate { get; set; }
        
        public string Comment { get; set; }

        public Status Status { get; set; }

        //[Column(TypeName = "money")]
        public decimal ShipCharge { get; set; }//unUsed!

        public String Tracking { get; set; }//UnUsed

        public List<OrderDetail> OrderDetails { get; set; }

        public virtual Contact Contact { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderShipping> OrderShippings { get; set; }

        //public virtual ICollection<Shipment> Shipments { get; set; }
    }
}