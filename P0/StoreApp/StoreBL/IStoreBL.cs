using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IPartsBL
    {
        List<Customer> GetCustomer();
        List<Order> GetOrder();
        void AddCustomer(Customer newCustomer);

        void AddOrder(Order newOrder);

        // List<Product> GetProduct();
        // void AddProduct(Product newProduct);
        // List<Item> GetItem();
        // void AddItem(Item newItem);

    }
}