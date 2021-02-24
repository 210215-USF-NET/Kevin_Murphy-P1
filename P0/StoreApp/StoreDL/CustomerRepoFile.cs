using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;
namespace StoreDL
{
    public class StoreRepoFile : IStoreRepository
    {
        private string jsonString;
        private string filePath = "../StoreDL/CustomerFiles.json";
        public Customer AddCustomer(Customer newCustomer)
        {
            List<Customer> customerFromFile = GetCustomer();
            customerFromFile.Add(newCustomer);
            jsonString = JsonSerializer.Serialize(customerFromFile);
            File.WriteAllText(filePath, jsonString);
            return newCustomer;

        }

     
        public List<Order> GetOrder()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                
               return new List<Order>();
            }
         
            return JsonSerializer.Deserialize<List<Order>>(jsonString);
        }

        public List<Customer> GetCustomer()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                
               return new List<Customer>();
            }
         
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public Order AddOrder(Order newOrder)
        {
            List<Order> orderFromFile = GetOrder();
            orderFromFile.Add(newOrder);
            jsonString = JsonSerializer.Serialize(orderFromFile);
            File.WriteAllText(filePath, jsonString);
            return newOrder;
        }
    }
}