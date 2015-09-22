using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Raw
    {
        [ScaffoldColumn(false)]
        public int RawId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Frontier Lot#")]
        public string LotNumber { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Display(Name = "Manufacturer Lot#")]
        public string ManLotNumber { get; set; }

        [Required]
        [Display(Name = "Manufacturer Part#")]
        public string ManPartNumber { get; set; }

        [Display(Name = "Date Received")]
        [DataType(DataType.Date)]
        public System.DateTime DateRecived { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(NullDisplayText = "N/A")]
        public System.DateTime? ExpDate { get; set; }

        [Display(Name = "Frontier Product#")]
        public int ProductId { get; set; }

        [Display(Name = "Frontier Product#")]
        public virtual Product Product { get; set; } 
    }
}