using System.Collections.Generic;
using Model =  StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class StoreDB : IStoreRepository
    {
        public Customer AddCustomer(Customer newCustomer)
        {
            throw new System.NotImplementedException();
        }

        public Order AddOrder(Order newOrder)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetCustomer()
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}