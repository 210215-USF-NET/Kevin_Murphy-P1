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
            return _context.Customers.Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public List<Order> GetOrder()
        {
            return _context.StoreOrders.Select(x => _mapper.ParseOrder(x)).ToList();
        }
    }
}