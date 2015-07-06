using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum State
    {
        AK, AL, AR, AZ, CA, CO, CT, DC, DE, FL, GA, HI, IA, ID, IL, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MS, MT, NC, ND, NE, NH, NJ, NM, NV, NY, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VA, VT, WA, WI, WV, WY, other
    }

    public enum CType
    {
        Customer, Vendor
    }

    public enum PhoneType
    {
        Home, Business, Cell
    }

    public class Contact
    {
        [Key]        
        [ScaffoldColumn(false)]        
        public int ContactId { get; set; }

        [Index(IsUnique = true)]
        [Required, StringLength(100)]
        //[ReadOnlyAttribute(true)]
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

        [Display(Name = "Secondary Phone")]
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

        [Display(Name = "Contact Type")]
        public CType Type { get; set; }

        [ScaffoldColumn(false)]        
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Shipping> Shippings { get; set; }

        //public virtual ICollection<Shipment> Shipments { get; set; }
    }
}