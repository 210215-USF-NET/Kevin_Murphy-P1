using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted)
        {
            return new CustomerIndexVM
            {
                CustomerName = customer2BCasted.CustomerName,
                CarType = customer2BCasted.CarType,
                PhoneNumber = customer2BCasted.PhoneNumber
            };

        }
        public Customer cast2Customer(CustomerCRVM customer2BCasted)
        {
            return new Customer
            {
                CustomerName = customer2BCasted.CustomerName,
                PhoneNumber = customer2BCasted.PhoneNumber,
                CarType = customer2BCasted.CarType
            };
        }

        public CustomerCRVM cast2CustomerCRVM(Customer customer)
        {
            return new CustomerCRVM
            {
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CarType = customer.CarType
            };
        }

        public Location cast2Location(LocationCRVM location2BCasted)
        {
            return new Location
            {
                LocationName = location2BCasted.LocationName,
                Address = location2BCasted.Address
            };
        }

        public LocationCRVM cast2LocationCRVM(Location location)
        {
           return new LocationCRVM{
               LocationName = location.LocationName,
               Address = location.Address
            };
        }

        public LocationIndexVM cast2LocationIndexVM(Location location2BCasted)
        {
            return new LocationIndexVM
            {
                Address = location2BCasted.Address,
                LocationName = location2BCasted.LocationName
            };
        }

        public Product cast2Product(ProductCRVM product2BCasted)
        {
            return new Product
            {
                ProductName = product2BCasted.ProductName,
                Price = product2BCasted.Price,
                ProductDescription = product2BCasted.ProductDescription
            };
        }

        public ProductCRVM cast2ProductCRVM(Product product)
        {
            return new ProductCRVM
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductDescription = product.ProductDescription
            };
        }

        public ProductIndexVM cast2ProductIndexVM(Product product2BCasted)
        {
            return new ProductIndexVM
            {
                ProductName = product2BCasted.ProductName,
                Price = product2BCasted.Price,
                ProductDescription = product2BCasted.ProductDescription
            };
        }
    }

}
