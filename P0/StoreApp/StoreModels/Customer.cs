using System;
using System.Text.RegularExpressions;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {

        private string customerName;
        public string CustomerName
        {  
            get{return customerName;}
            set
            {
                if(value == null || value.Equals(""))
                {
                   throw new ArgumentNullException("Customer name can not be null or empty");
                }
                customerName = value;
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get{return phoneNumber;} 
            set
            {
                Match match = Regex.Match(value, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}");
                if(!match.Success)
                {
                    throw new Exception("Number must be of form (xxx)xxx-xxxx");
                }
                phoneNumber = value;
             
            }
        }
        //public string ID { get; set; }
        public CarType CarType { get; set; }
        public int? Id { get; set; }

        public override string ToString() => $"Customer Details: \n\t name: {this.CustomerName} \n\t phone number: {this.PhoneNumber} \n\t Car Type: {this.CarType} ";
        //TODO: add more properties to identify the customer
    }
}