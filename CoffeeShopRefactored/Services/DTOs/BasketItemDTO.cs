using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;

namespace Services
{
    public class BasketItemDTO
    {
        public int BasketItemId { get; set; }
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int Product_Id { get; set; }
        public string Product_name { get; set; }
        public int Basket_Id { get; set; }

    }
}
