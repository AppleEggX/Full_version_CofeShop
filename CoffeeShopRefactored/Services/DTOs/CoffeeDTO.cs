using Pocos;

namespace Services
{

    public class CoffeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CountryOfOrigin Origin { get; set; }
        public int Stock { get; set; }
        public CoffeeType CoffeeType { get; set; }
        public int Strength { get; set; }
    }
}
