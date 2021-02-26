
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
        
        // Order AddProduct(Product newProduct);
        // List<Product> GetProduct();

        // Order AddItem(Item newItem);
        // List<Item> GetItem();

    }
}