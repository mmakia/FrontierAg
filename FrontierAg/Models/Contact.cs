﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY, other
    }

    public enum CType
    {
        Customer, Vendor, Employee, Other
    }

    public enum PhoneType
    {
        Home, Business, Cell
    }

    public class Contact
    {
        [Key]        
        [ScaffoldColumn(true)]
        [Display(Name = "Contact ID")]
        public int ContactId { get; set; }

        //[Display(Name = "Contact ID")]
        //public string Contact_Identification { get; set; }

        [Required, StringLength(100)]
        public string Company { get; set; }
        
        public string LName { get; set; }
        
        public string FName { get; set; }        

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public State? State { get; set; }

        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Primary Phone Number is required"), Display(Name = "Primary Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PPhone { get; set; }

        [Required(ErrorMessage = "Type of Phone number is required"), Display(Name = "Phone Type")]
        public PhoneType PPType { get; set; }

        [Display(Name = "Secondary Phone")]
        public string SPhone { get; set; }

        [Display(Name = "Secondary Phone Type")]
        public PhoneType? SPType { get; set; }

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

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Shipping> Shippings { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}