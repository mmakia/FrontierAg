using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Customer
    {        
        [ScaffoldColumn(false)]
        public int CustomerId { get; set; }                
       
        public string Company { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }               

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

        //[Display(Name = "Secondary Phone")]
        public string SPhone { get; set; }        

        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EMail { get; set; }

        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }            

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Order> Orders { get; set; }        
    }
}