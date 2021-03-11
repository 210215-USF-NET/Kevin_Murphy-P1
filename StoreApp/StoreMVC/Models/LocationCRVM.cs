using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;

namespace StoreMVC.Models
{
    public class LocationCRVM
    {
        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [DisplayName("Location Address")]
        public string Address { get; set; }


    }
}
