using System;
namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
       
        public string ProductName 
        {get; set;}
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public int Id { get; set; }
      
        //todo: add more properties to define a product (maybe a category?)
        public override string ToString() => $"\n\t name: {this.ProductName}\n\t Description: {this.ProductDescription} \n\t price: {this.Price}\n\t";

    }
}