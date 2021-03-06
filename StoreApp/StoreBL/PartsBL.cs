﻿using System;
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
         public void AddIO(Item I)
        {
            _repo.AddIO(I);
        }

        public List<Customer> GetCustomer()
        {
            return _repo.GetCustomer();
        }
        public List<Location> GetLocation()
        {
            return _repo.GetLocation();
        }

        

        public List<Order> GetOrder()
        {
            return _repo.GetOrder();
        }

    

        public Customer GetCustomerByNumber(string number)
        {
            return _repo.GetCustomerByNumber(number);
        }

        public Location GetLocationByName(string name)
        {
            return _repo.GetLocationByName(name);
        }
          public Location GetLocationById(int? Id)
        {
            return _repo.GetLocationById(Id);
        }

        public List<Product> GetProduct()
        {
           return _repo.GetProduct();
        }

       

        public Product GetProductByName(string name)
        {
            return _repo.GetProductByName(name);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<Item> GetLocationItems()
        {
            return _repo.GetLocationItems();
        }

        public Product GetProductById(int? Id)
        {
            return _repo.GetProductById(Id);
        }

        public Customer GetCustomerById(int? Id)
        {
            return _repo.GetCustomerById(Id);
        }

        public Item GetItemByOID(int? Id)
        {
           return _repo.GetItemByOID(Id);
        }

       
    }

}
