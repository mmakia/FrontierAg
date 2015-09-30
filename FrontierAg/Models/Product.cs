using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product # is required."), StringLength(20), Display(Name = "Product#")]
        public string ProductNo { get; set; }

        [Required(ErrorMessage = "Product Name is required."), StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }

        //[Display(Name = "Full Name")]
        [ScaffoldColumn(false)]
        public string ProductNoName
        {
            get
            {
                return ProductNo + " >> " + ProductName;
            }
        }

        public DateTime DateCreated { get; set; } 

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }        

        public virtual ICollection<Price> Prices { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual ICollection<PackCharge> PackCharges { get; set; }

        public virtual ICollection<Raw> Raws { get; set; }
    }
}