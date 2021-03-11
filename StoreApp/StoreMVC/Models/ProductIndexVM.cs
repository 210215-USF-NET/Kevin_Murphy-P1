using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class ProductIndexVM
    {
        [DisplayName("Product Name")]
        
        public string ProductName { get; set; }

        [DisplayName("Product Price")]

        public double Price { get; set; }
        //public string ID { get; set; }
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }
    }
}
