using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public enum Unit
    {
        Kg, Liter, Cup, Container, Tray, Batch, Case, Pack, Each, Hundred, Thousand, Roll, Box, Jug 
    }
    
    public class Price
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PriceId { get; set; }

        [Range(0,int.MaxValue)]
        public int From { get; set; }

        [Range(0,int.MaxValue)]
        public int To { get; set; }       

        [Required]
        public Unit Unit { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal PriceNumber { get; set; }
        
        public DateTime DateCreated { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}