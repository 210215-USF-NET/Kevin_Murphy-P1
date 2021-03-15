using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }

        //public ICollection<Orderline> Orderlines { get; set; }
        //TODO: add a property for the order items
       //public ICollection<Product> Products { get; set; }

        [Required]
        public int Quantity { get; set;  }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set;  }
 
        public int ProductId { get; set;  }
        //public int Quanity { get; set; }

        public override string ToString() =>  $" Total: ${this.Total}";// $"\n\t location name:  Item name: {this.Item.ToString()} \n\t{this.Location.ToString()}"{this.Customer.ToString()} \n\t;
    }
}