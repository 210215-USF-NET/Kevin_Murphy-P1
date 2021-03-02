namespace StoreModels
{
    public class OIS
    {    public int Quantity { get; set; }

        public int? PFK { get; set; }
        public override string ToString() => $" \n\t  item Quanity: {this.Quantity} ";

    }
}