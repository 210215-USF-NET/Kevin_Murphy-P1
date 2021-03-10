using System;
using System.Text.RegularExpressions;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {

   
        public string CustomerName { get;set ;}

        public string PhoneNumber{ get ;set;}
        //public string ID { get; set; }
        public CarType CarType { get; set; }
        public int Id { get; set; }

        public override string ToString() => $"Customer Details: \n\t name: {this.CustomerName} \n\t phone number: {this.PhoneNumber} \n\t Car Type: {this.CarType} \n\t ";
        //TODO: add more properties to identify the customerser ID: {this.Id}"
    }
}