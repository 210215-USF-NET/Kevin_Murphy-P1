using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class OrderCRVM
    {
        public int CustomerId { get; set; }
        public int LocaitonId { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }

        public  int Quantitiy { get; set; }
        public  int OrderId { get; set;  }
        [DisplayName("Your Number")]
        public string CustomerNumber { get; set; }
        [DisplayName("Order Location Name")]
        public string LocationName { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

    }
}
