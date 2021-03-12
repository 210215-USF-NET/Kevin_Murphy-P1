using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModels
{
   public class Inventory
    {
        public int ID { get; set; }
        public Location Location { get; set;  }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
