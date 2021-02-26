using System;
namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        private string productName;
        public string ProductName 
        {    
            get{return productName;}
            set
            {
                if(value == null || value.Equals(""))
                {
                   throw new ArgumentNullException("Product name can not be null or empty");
                }
                productName = value;
            }
        }
        public double Price { get; set; }
        public int? Id { get; set; }
      
        //todo: add more properties to define a product (maybe a category?)
        public override string ToString() => $"\n\t name: {this.ProductName}  \n\t location name: {this.Price}\n\t";

    }
}