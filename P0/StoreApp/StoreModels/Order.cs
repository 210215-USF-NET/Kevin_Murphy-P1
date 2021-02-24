namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        public Customer Customer { get; 
        set; }
        public Location Location { get; set; }
        public double Total { get; set; }

        //TODO: add a property for the order items
        public override string ToString() => $"\n\t name: {this.Customer}  \n\t location name: {this.Location} \n\t location name: {this.Total}";
    }
}