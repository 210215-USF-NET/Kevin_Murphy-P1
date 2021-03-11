using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;


namespace StoreMVC.Models
{
    public class ProductCRVM
    {
        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Product Price")]
        [Required]

        public double Price { get; set; }
        //public string ID { get; set; }
        [DisplayName("Product Description")]
        [Required]
        public string ProductDescription { get; set; }

    }
}
