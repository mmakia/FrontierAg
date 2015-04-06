using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required."), StringLength(100), Display(Name = "Name")]
        public string CategoryName { get; set; }        

        public DateTime DateCreated { get; set; }        

        public virtual ICollection<Product> Products { get; set; }

     }
}