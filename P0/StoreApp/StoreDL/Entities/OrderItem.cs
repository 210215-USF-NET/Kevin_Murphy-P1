using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? StoreOrder { get; set; }
        public int? Product { get; set; }

        public virtual Product ProductNavigation { get; set; }
        public virtual StoreOrder StoreOrderNavigation { get; set; }
    }
}
