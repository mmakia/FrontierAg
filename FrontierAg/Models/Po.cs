using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Po
    {
        [ScaffoldColumn(false)]
        public int PoId { get; set; }

        [Required, Display(Name="PO Number")]
        public string PoNumber { get; set; }

        [Display(Name="Company")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}