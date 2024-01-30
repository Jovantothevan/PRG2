using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10262621_PRG2Assignment
{
    class Waffle:IceCream
    {
        public string WaffleFlavour {  get; set; }
        public Waffle() { }
        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, string waffleFlavour) : base(option, scoops, flavours, toppings)
        {
            WaffleFlavour = waffleFlavour;
        }

        public override double CalculatePrice()
        {
            double price = 0;
            if (Scoops == 1)
            {
                price += 7;

            }
            else if (Scoops == 2)
            {
                price += 8.5;
            }
            else
            {
                price += 9.5;
            }
            foreach (Flavour flavour in Flavours)
            {
                if (flavour.Premium)
                {
                    price += 2 * flavour.Quantity;
                }
            }
            foreach (Topping topping in Toppings)
            {
                price += 1;
            }

            return price;
        }

        public override string ToString()
        {
            return base.ToString() + " WaffleFlavour: " + WaffleFlavour;
        }
    }
}
