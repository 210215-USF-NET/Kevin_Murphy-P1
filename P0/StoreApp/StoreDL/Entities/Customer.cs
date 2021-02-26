using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            StoreOrders = new HashSet<StoreOrder>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int? CarType { get; set; }

        public virtual CarType CarTypeNavigation { get; set; }
        public virtual ICollection<StoreOrder> StoreOrders { get; set; }
    }
}
