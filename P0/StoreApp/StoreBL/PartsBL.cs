using System;
using System.Collections.Generic;
using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class PartsBL : IPartsBL
    {
        private IStoreRepository _repo;

        public PartsBL(IStoreRepository repo){
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            _repo.AddCustomer(newCustomer);
        }

        public void AddOrder(Order newOrder)
        {
            _repo.AddOrder(newOrder);
        }

        public List<Customer> GetCustomer()
        {
            return _repo.GetCustomer();
        }

        public List<Order> GetOrder()
        {
            return _repo.GetOrder();
        }

        //  public void AddProduct(Product newProduct)
        // {
        //     _repo.AddProduct(newProduct);
        // }

        // public List<Product> GetProduct()
        // {
        //     return _repo.GetProduct();
        // }

        //   public void AddItem(Item newItem)
        // {
        //     _repo.AddItem(newItem);
        // }

        // public List<Item> GetItem()
        // {
        //     return _repo.GetItem();
        // }

    
    }

}
