using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;

namespace StoreDL
{
    public class OrderRepoFile : IOrderRepository
    {
        private string jsonString;
        private string filePath = "../StoreDL/OrderFiles.json";
        public Order AddOrder(Order newOrder)
        {
             List<Order> orderFromFile = GetOrder();
            orderFromFile.Add(newOrder);
            jsonString = JsonSerializer.Serialize(orderFromFile);
            File.WriteAllText(filePath, jsonString);
            return newOrder;
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
    }
}