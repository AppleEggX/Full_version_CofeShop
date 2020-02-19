using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        //A BasketItem is kind of product
        public virtual Product Product { get; set; }
        //A BasketItem is located into a basket
        public virtual Basket Basket { get; set; }
    }
}
