using System;
namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Item
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int? Id { get; set; }
        public int? LFK { get; set; }
        
        public int? PFK { get; set; }

        public override string ToString() => $" \n\t  item name: {this.Quantity} ";


    }
}