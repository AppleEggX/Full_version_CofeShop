using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class Basket
    {
        public int Id { get; set; }

        public decimal SumPrice { get; set; }

        //Each basket has one user
        //A basket is linked to a user/cookies
        public virtual User User { get; set; }

        public bool Paid { get; set; }

        // Basket has many basketItems
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
