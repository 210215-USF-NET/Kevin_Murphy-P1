using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IStoreBL
    {
        List<Customer> GetCustomer();
        void AddCustomer(Customer newCustomer);
    }
}