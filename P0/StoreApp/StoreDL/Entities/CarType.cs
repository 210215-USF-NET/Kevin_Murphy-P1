using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class CarType
    {
        public CarType()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string CarType1 { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
