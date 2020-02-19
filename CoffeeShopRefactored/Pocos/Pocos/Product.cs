using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public enum ProductType
    {
        Coffee,
        Course
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
