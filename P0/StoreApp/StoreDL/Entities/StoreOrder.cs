using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreOrder
    {
        public StoreOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public double Total { get; set; }
        public int? Customer { get; set; }
        public int? Location { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
