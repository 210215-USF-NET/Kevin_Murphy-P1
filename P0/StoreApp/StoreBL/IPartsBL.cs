using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IPartsBL
    {
        List<Customer> GetCustomer();
        List<Order> GetOrder();
        List<Location> GetLocation();
        List<Product> GetProduct();

        List<Product> GetProducts();

        void AddCustomer(Customer newCustomer);

        void AddOrder(Order newOrder);
        Customer GetCustomerByNumber(string number);
      
        Location GetLocationByName(string name);
        Product GetProductByName(string name);


    }
}