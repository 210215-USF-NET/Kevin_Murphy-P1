using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreMVC.Models
{
    public class OrderDetailVM
    {
        public string CustomerName { get; set; }
        public string  LocationName { get; set; }
        public string ProductName { get; set; }
        public double Total { get; set; }
        public int Quanity { get; set; }
    }
}
