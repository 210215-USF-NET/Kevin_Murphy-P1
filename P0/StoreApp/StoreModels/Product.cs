using System;
namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        public string ProductName {    
            get{return ProductName;}
            set
            {
                if(value == null || value.Equals(""))
                {
                   throw new ArgumentNullException("Product name can not be null or empty");
                }
                ProductName = value;
            }}
        public double Price { get; set; }
      
      
        //todo: add more properties to define a product (maybe a category?)
        public override string ToString() => $"\n\t name: {this.ProductName}  \n\t location name: {this.Price}\n\t";

    }
}