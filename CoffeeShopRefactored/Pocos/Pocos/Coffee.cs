using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public enum CoffeeType
    {
        Arabica,
        Robusta,
        Liberica,
        Excels,
        Aeropress,
        Chemex,
        Espresso,
        FrenchPress,
        PourOver,
        Decaf
    }

    public enum CountryOfOrigin
    {
        CountryOfOrigin,
        Angola,
        Bolivia,
        China,
        Colombia,
        Cuba,
        Ecuador,
        Ethiopia,
        Guatemala,
        Kenya,
        Nicaragua,
        Tanzania,
        Venezuela,
        Vietnam
    }

    public class Coffee : Product
    {

        public CountryOfOrigin Origin { get; set; }
        public int Stock { get; set; }
        public CoffeeType CoffeeType { get; set; }
        public int Strength { get; set; } // remember to limit this to between 1-5 in the front end

        public string Imgurl { get; set; }
    
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
