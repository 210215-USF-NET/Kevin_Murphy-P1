using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string InventoryName { get; set; }
        public int Quantity { get; set; }
        public int? Location { get; set; }

        public virtual Location LocationNavigation { get; set; }
    }
}
