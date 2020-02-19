using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;

namespace Services
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double PercentDiscount { get; set; }
        public int Quantity { get; set; }
        public User User { get; set; }
        public Coffee Coffee { get; set; }
    }
}
