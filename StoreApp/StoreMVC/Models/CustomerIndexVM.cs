using StoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class CustomerIndexVM
    {
        [DisplayName("Customer Name") ]
        public string CustomerName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        //public string ID { get; set; }
        [DisplayName("Car Type")]
        public CarType CarType { get; set; }
        
    }
}
