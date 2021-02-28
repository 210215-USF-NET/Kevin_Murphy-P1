using System.Collections.Generic;
using Model =StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class StoreRepoDB : IStoreRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public StoreRepoDB(Entity.StoreDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return(newCustomer);
        }

        public Order AddOrder(Order newOrder)
        {
            _context.StoreOrders.Add(_mapper.ParseOrder(newOrder));
            _context.SaveChanges();
            return(newOrder);
        }

        public List<Customer> GetCustomer()
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public Customer GetCustomerByNumber(string number)
        {
            
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.PhoneNumber ==number);
        }
        }

        public List<Location> GetLocation()
        {
             return _context.Locations.AsNoTracking().Include("Product").Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public Location GetLocationByName(string name)
        {
           return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList().FirstOrDefault(x => x.LocationName == name);
        }

        public Product GetProductByName(string name)
        {
           return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.ProductName == name);
        }

        public List<Order> GetOrder()
        {
            return _context.StoreOrders.AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
            
        }

        public List<Product> GetProduct()
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList();

        }

        public List<Product> GetProducts()
        {
            return _context.Products.Select(x => _mapper.ParseProduct(x)).ToList();
        }

         public List<Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList();
        }
    }
}