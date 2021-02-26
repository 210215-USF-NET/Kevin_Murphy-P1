namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public string Address { get; set; }
        public string LocationName { get; set; }
        //TODO: add some property for the location inventory
        public Product Product{get; set;}
        public int? Id { get; set; }
        public override string ToString() => $"Customer Details: \n\t Address: {this.Address} \n\t Location Name: {this.LocationName} ";
    }
}