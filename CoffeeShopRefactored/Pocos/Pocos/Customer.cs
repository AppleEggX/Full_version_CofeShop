using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class Customer : User
    {
        public string AddressLn1 { get; set; }
        public string AddressLn2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string DeliveryPreferences { get; set; }
   
    }
}
