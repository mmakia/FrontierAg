using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class ShipmentDetail
    {
        public int ShipmentDetailId { get; set; }

        public int ShipmentId { get; set; }

        public int ProductId { get; set; }

        public string ProductNo { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public string UnitString { get; set; }

        //[Column(TypeName = "money")]
        public decimal Price { get; set; }//decimal

        //[Column(TypeName = "money")]
        public decimal PCharge { get; set; }//decimal

        public int QtyShipped { get; set; }     

        public int QtyShipping { get; set; }

        public int QtyCancelled { get; set; }

        public String Comment { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}