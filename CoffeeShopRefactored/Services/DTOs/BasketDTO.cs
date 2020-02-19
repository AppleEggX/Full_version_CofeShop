using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public decimal SumPrice { get; set; }
        public bool Paid { get; set; }

        public int User_Id { get; set; }
    }
}
