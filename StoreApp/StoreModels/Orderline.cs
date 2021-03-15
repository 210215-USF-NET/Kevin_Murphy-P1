using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModels
{
    public class Orderline
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Order Order { get; set;  }
        public int OrderId { get; set; }
    }
}
