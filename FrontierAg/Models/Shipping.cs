using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Shipping
    {
        
        public int ShippingId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public State? State { get; set; }

        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Display(Name="Company")]
        public int? ContactId { get; set; }

        public Contact Contact { get; set; }        

        public virtual ICollection<Order> Orders { get; set; }
    }
}