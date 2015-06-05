using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }        

        public int OrderId { get; set; }

        public int ShippingId { get; set; }

        public String Tracking { get; set; }

        public Decimal PFee { get; set; }

        public Decimal PCharges { get; set; }

        public Decimal ShipCharge { get; set; } 

        public String Comment { get; set; }

        public DateTime DateCreated { get; set; }

        public Decimal Total { get; set; }        

        public virtual Order Order { get; set; }

        public virtual Shipping Shipping { get; set; }

        public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; }


    }
}