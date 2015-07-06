using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class PackCharge
    {
        public int PackChargeId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public int From { get; set; }

        [Range(0, int.MaxValue)]
        public int To { get; set; }

        [Required(ErrorMessage = "Packaging Charge is required.")]
        //[Column(TypeName = "money")]
        public decimal PackChargeAmt { get; set; }//decimal

        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }
        
    }
}