using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class Raw
    {
        [ScaffoldColumn(false)]
        public int RawId { get; set; }

        public string LotNumber { get; set; }

        public string Manufacturer { get; set; }
        
        public string ManLotNumber { get; set; }

        public string ManPartNumber { get; set; }

        public System.DateTime DateRecived { get; set; }

        public System.DateTime ExpDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}