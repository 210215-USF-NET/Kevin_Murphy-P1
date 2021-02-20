using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IPartsBL
    {
        List<Customer> GetCustomer();
        void AddCustomer(Customer newCustomer);
    }
}