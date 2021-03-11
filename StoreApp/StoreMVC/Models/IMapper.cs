using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        Customer cast2Customer(CustomerCRVM customer2BCasted);
        CustomerCRVM cast2CustomerCRVM(Customer customer);
        CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted);
    }
}