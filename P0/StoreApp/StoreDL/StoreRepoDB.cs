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
        public Customer temp = new Customer();
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
         Model.Customer customerTemp = new Model.Customer();

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
            customerTemp= _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.PhoneNumber ==number);

            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.PhoneNumber ==number);
        }
        public Customer GetCustomerById(int? Id)
        {
            temp = _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.Id ==Id);
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.Id ==Id);
        }

        public List<Location> GetLocation()
        {
             return _context.Locations.AsNoTracking().Include("Product").Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public Location GetLocationByName(string name)
        {
           return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList().FirstOrDefault(x => x.LocationName == name);
        }
        public Location GetLocationById(int? Id)
        {
           return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList().FirstOrDefault(x => x.Id == Id);
        }

        public Product GetProductByName(string name)
        {
           return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.ProductName == name);
        }

        
        public List<Order> GetOrder()
        {
            return _context.StoreOrders.AsNoTracking().Select(x => _mapper.ParseOrder(x)).ToList();
    
        }
        public List<Item> GetLocationItems()
        {
            return _context.Inventories.AsNoTracking().Select(x => _mapper.ParseItem(x)).ToList();
    
        }
        // public List<Order> GetOrderFK(int? customer)
        // {
        //     return _context.StoreOrders.AsNoTracking().Select(x => _mapper.ParseOrderFK(x)).ToList().All(x => x.CFK == customer);
            
        // }

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

        public Product GetProductById(int? Id)
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList().FirstOrDefault(x => x.Id == Id);
        }
    }
}