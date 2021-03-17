using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StoreModels;

namespace StoreTests
{
    public class StoreModelTests
    {
        private Customer testCustomer = new Customer();
        private Location testLocation = new Location();
        private Product testProduct = new Product();
        [Fact]
        public void CustomerNameShouldBeSet()
        {
            string customerNamer = "Customer";
            testCustomer.CustomerName = customerNamer;
            Assert.Equal(customerNamer, testCustomer.CustomerName);
        }
        [Fact]
        public void CustomerNumberShouldBeSet()
        {
            string customerNumber = "222-222-2222";
            testCustomer.PhoneNumber = customerNumber;
            Assert.Equal(customerNumber, testCustomer.PhoneNumber);
        }

        [Fact]
        public void LocationNameShouldBeSet()
        {
            string locationName = "Name";
            testLocation.LocationName = locationName ;
            Assert.Equal(locationName, testLocation.LocationName);
        }
        [Fact]
        public void LocationAddressShouldBeSet()
        {
            string locationAddress = "Addy";
            testLocation.Address = locationAddress;
            Assert.Equal(locationAddress, testLocation.Address);
        }
        [Fact]
        public void ProductNameShouldBeSet()
        {
            string productName= "Prod";
            testProduct.ProductName= productName;
            Assert.Equal(productName, testProduct.ProductName);
        }
        [Fact]
        public void ProductPriceShouldBeSet()
        {
            double productPrice = 12;
            testProduct.Price = productPrice;
            Assert.Equal(productPrice, testProduct.Price);
        }

    }
}
