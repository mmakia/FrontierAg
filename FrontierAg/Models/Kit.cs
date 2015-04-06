using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Kit
    {
        [ScaffoldColumn(false)]
        public int KitId { get; set; }

        [Required]
        public string KitNo { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string KitName { get; set; }

        public string KitDescription { get; set; }
        
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Product> Products{ get; set; }

        public virtual ICollection<Price> Prices { get; set; }
    }
}