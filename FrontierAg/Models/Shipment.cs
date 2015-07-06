using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum Action
    {
        Cancel, New, ToInvoice, Invoiced, Paid
    }

    public class Shipment
    {
        public int ShipmentId { get; set; }        

        public int OrderId { get; set; }

        public int ShippingId { get; set; }

        public String Tracking { get; set; }

        //[Column(TypeName = "money")]
        public decimal PFee { get; set; }//decimal

        //[Column(TypeName = "money")]
        public decimal PCharges { get; set; }//decimal

        //[Column(TypeName = "money")]
        public decimal ShipCharge { get; set; } //decimal

        //[Column(TypeName = "money")]
        public decimal OtherCharges { get; set; }

        public Action? Action { get; set; }

        public String Comment { get; set; }

        public DateTime DateCreated { get; set; }

        //[Column(TypeName = "money")]
        public decimal Total { get; set; }//decimal

        public virtual Order Order { get; set; }

        public virtual Shipping Shipping { get; set; }

        public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; }
        
    }
}