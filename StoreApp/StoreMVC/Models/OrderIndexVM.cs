using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class OrderIndexVM
    {
        public int LocationId { get; set; }
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        
    }
}
