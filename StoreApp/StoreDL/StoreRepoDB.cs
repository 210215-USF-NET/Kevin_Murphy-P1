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

        public Item AddItem(Item newItem)
        {
            _context.Item.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public Location AddLocation(Location newLocation)
        {
            _context.Locations.Add(newLocation);
            _context.SaveChanges();
            return newLocation;
        }

        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
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
        public Order DeleteOrder(Order order2BDeleted)
        {
            _context.Orders.Remove(order2BDeleted);
            _context.SaveChanges();
            return order2BDeleted;
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

        public Location GetLocationById(int Id)
        {
            return _context.Locations.AsNoTracking().FirstOrDefault(location => location.Id ==Id);
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
            return _context.Orders.AsNoTracking().Select(order => order).ToList();
        }

        public List<Order> GetOrderByCustomerId(int Id)
        {
            return _context.Orders.AsNoTracking().Where(order => order.Customer.Id == Id).ToList();
        }

        public Order GetOrderById(int Id)
        {
            return _context.Orders.AsNoTracking().FirstOrDefault(order => order.Id == Id);
        }

        public List<Order> GetOrderByLocationId(int Id) 
        {
            return _context.Orders.AsNoTracking().Where(order => order.LocationId == Id).ToList();
        }

        public List<Orderline> GetOrderline()
        {
           return _context.Orderlines.AsNoTracking().Select(orderline => orderline).ToList();
        }

        public List<Product> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int Id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(product => product.Id == Id);
        }

        public List<Product> GetProductByLocationId(int Id)
        {
            return _context.Products.AsNoTracking().Where(product => product.LocationId == Id).ToList();
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
