using StoreModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{   /// <summary>
    ///Customer view model for creation and reading
    /// </summary>
    public class CustomerCRVM
    {
        [DisplayName("Customer Name")]
        [Required]
        public string CustomerName { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        //public string ID { get; set; }
        [DisplayName("Car Type")]
        [Required]
        public CarType CarType { get; set; }
       
    }
}
