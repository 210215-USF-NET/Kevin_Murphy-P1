using System;
using System.Collections.Generic;
using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class CustomerBL : IStoreBL
    {
        private IStoreRepository _repo;

        public CustomerBL(IStoreRepository repo){
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomer()
        {
            return _repo.GetCustomer();
        }
    }

}
