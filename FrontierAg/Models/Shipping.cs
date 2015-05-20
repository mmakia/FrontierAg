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

        public string Company { get; set; }

        public string LName { get; set; }

        public string FName { get; set; }   

        public string Other1 { get; set; }

        public string Other2 { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public State? State { get; set; }

        [DataType(DataType.PostalCode)]
        public String PostalCode { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PPhone { get; set; }

        public bool isShipping { get; set; }

        public bool isHistory { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        
        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }        

        public virtual ICollection<OrderShipping> OrderShippings { get; set; }
    }
}