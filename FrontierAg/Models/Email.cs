using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Email
    {
        [ScaffoldColumn(false)] 
        public int EmailId { get; set; }

        [Display(Name = "Email Address")]
        public String EmailAddress { get; set; }

        [Display(Name = "Notify when new Order")]
        public bool isForOrder { get; set; }

        [Display(Name = "Notify when Shipment ready ToInvoice")]
        public bool isForShipment { get; set; }

        [ScaffoldColumn(false)] 
        public System.DateTime EmailDate { get; set; }
    }
}