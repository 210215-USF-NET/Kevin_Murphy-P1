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
        List<Location> GetLocations();

        void AddCustomer(Customer newCustomer);

        void AddOrder(Order newOrder);
        void AddIO(Item I);
        Customer GetCustomerByNumber(string number);
      
        Location GetLocationByName(string name);
        Location GetLocationById(int? Id);
        Customer GetCustomerById(int? Id);
        Product GetProductByName(string name);
    
        List<Item> GetLocationItems();
        Product GetProductById(int? Id);
        Item GetItemByOID(int? Id);

    }
}