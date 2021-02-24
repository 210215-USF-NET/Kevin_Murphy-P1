using System.Collections.Generic;
using System;
using StoreModels;
namespace StoreDL
{
    public interface IOrderRepository
    {
         List<Order> GetOrder();

         Order AddOrder(Order newOrder);
         
        
    }
}