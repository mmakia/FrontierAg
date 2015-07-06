using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum SType
    {
        Shipping, Billing, Ordering
    }

    public class OrderShipping
    {
        public int OrderShippingId { get; set; }

        public int OrderId { get; set; }

        public int ShippingId { get; set; }

        public SType SType { get; set; }

        public virtual Order Order { get; set; }

        public virtual Shipping Shipping { get; set; }
    }
}