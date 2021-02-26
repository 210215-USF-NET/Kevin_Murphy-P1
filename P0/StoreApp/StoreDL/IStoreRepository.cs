
using StoreModels;
using System.Collections.Generic;
namespace StoreDL

{
    public interface IStoreRepository
    {
        List<Customer> GetCustomer();

        Customer AddCustomer(Customer newCustomer);

        Order AddOrder(Order newOrder);
        List<Order> GetOrder();
        List<Location> GetLocation();
        List<Product> GetProduct();

        Customer GetCustomerByNumber(string number);
        Product GetProductByName(string name);
        Location GetLocationByName(string name);

        // Order AddProduct(Product newProduct);
        // List<Product> GetProduct();

        // Order AddItem(Item newItem);
        // List<Item> GetItem();

    }
}