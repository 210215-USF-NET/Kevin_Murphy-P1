using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class Mapper :  IMapper
    {
        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted)
        {
            return new CustomerIndexVM
            {
                CustomerName = customer2BCasted.CustomerName,
                CarType = customer2BCasted.CarType,
                PhoneNumber = customer2BCasted.PhoneNumber
            };

        }
        public Customer cast2Customer(CustomerCRVM customer2BCasted)
        {
            return new Customer
            {
                CustomerName = customer2BCasted.CustomerName,
                PhoneNumber = customer2BCasted.PhoneNumber,
                CarType = customer2BCasted.CarType
            };
        }
    }

}
