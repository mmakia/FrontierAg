using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int ContactId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Decimal UnitPrice { get; set; }

    }
}