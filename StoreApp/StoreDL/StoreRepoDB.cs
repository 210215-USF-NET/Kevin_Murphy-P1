using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class StoreRepoDB : IStoreRepository
    {
        private readonly StoreDBContext _context;
        public StoreRepoDB(StoreDBContext context)
        {
            _context = context;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }

        public Item AddIO(Item I)
        {
            throw new NotImplementedException();
        }

        public Location AddLocation(Location newLocation)
        {
            _context.Locations.Add(newLocation);
            _context.SaveChanges();
            return newLocation;
        }

        public Order AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public Product AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public Location DeleteLocation(Location location2BDeleted)
        {
            _context.Locations.Remove(location2BDeleted);
            _context.SaveChanges();
            return location2BDeleted;
        }

        public Product DeleteProduct(Product product2BDeleted)
        {
            _context.Products.Remove(product2BDeleted);
            _context.SaveChanges();
            return product2BDeleted;
        }

        public List<Customer> GetCustomer()
        {
            return _context.Customers
                .AsNoTracking()
                .Select(customer => customer)
                .ToList();
        }

        public Customer GetCustomerById(int Id)
        {
            //could include the "Superpower using the .include method
            //return the first customer that has the id that matches the in put id
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(customer => customer.Id == Id);
        }

        public Customer GetCustomerById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByNumber(string number)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(customer => customer.PhoneNumber == number);
        }

        public Item GetItemByOID(int? Id)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocation()
        {
            return _context.Locations
                .AsNoTracking()
                .Select(location => location)
                .ToList();
        }

        public Location GetLocationById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocationByName(string name)
        {
            return _context.Locations.AsNoTracking().FirstOrDefault(location => location.LocationName == name);
        }

        public List<Item> GetLocationItems()
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrder()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int? Id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(product => product.ProductName == name);
        }

        public List<Product> GetProducts()
        {
            return _context.Products
               .AsNoTracking()
               .Select(product => product)
               .ToList();
        }
    }
}
