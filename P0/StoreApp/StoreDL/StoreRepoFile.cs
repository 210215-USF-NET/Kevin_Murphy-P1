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
        private string filePath = "../StoreDL/StoreFiles.json";
        public Customer AddCustomer(Customer newCustomer)
        {
            List<Customer> CustomerFromFile = GetCustomer();
            CustomerFromFile.Add(newCustomer);
            File.WriteAllText(filePath, jsonString);
            return newCustomer;

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
    }
}