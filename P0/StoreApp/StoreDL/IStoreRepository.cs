
using StoreModels;
using System.Collections.Generic;
namespace StoreDL

{
    public interface IStoreRepository
    {
        List<Customer> GetCustomer();

        Customer AddCustomer(Customer newCustomer);
    }
}