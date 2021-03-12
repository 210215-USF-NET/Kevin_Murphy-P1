
using StoreModels;
using System.Collections.Generic;
namespace StoreDL

{
    public interface IStoreRepository
    {
        List<Customer> GetCustomer();

        Customer AddCustomer(Customer newCustomer);
        Product AddProduct(Product newProduct);
        Location AddLocation(Location newLocation);
        Order AddOrder(Order newOrder);
        Item AddIO(Item I);
        List<Order> GetOrder();
        List<Location> GetLocation();
        List<Product> GetProduct();
        List<Product> GetProducts();

        List<Location> GetLocations();

        Customer GetCustomerByNumber(string number);
        Product GetProductByName(string name);
        Location GetLocationByName(string name);
        Location GetLocationById(int? Id);
        Product GetProductById(int? Id);
        Customer GetCustomerById(int? Id);
        List<Item> GetLocationItems();
        Item GetItemByOID(int? Id);
        Location DeleteLocation(Location location2BDeleted);
        Product DeleteProduct(Product product2BDeleted);

        // Order AddProduct(Product newProduct);
        // List<Product> GetProduct();

        // Order AddItem(Item newItem);
        // List<Item> GetItem();

    }
}